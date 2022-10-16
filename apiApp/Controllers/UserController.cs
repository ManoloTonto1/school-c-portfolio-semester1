using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using apiApp.models;
using System.Net;

namespace apiApp.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    byte[] salt = Encoding.ASCII.GetBytes("birchWood");
    private string hashPassword(string password)
    {
        // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password!,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
            
            return hashed;
    }
    models.DatabaseContext context = new models.DatabaseContext();
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<models.User> Get(int id)
    {
        return await Task.Run(() => context.users.Where(g => g.ID == id).First());

    }
    [HttpGet("all")]
    public async Task<IEnumerable<models.User>> GetAll(int limit = 10, int offset=0)
    {
        return await Task.Run(() => context.users.Skip(offset).Take(limit).ToList());
    }
    [HttpPost("login")]
    public models.User login([FromBody] userDataTransfer user)
    {
        var result = context.users.Where(u => u.userName == user.username && u.password == hashPassword(user.password)).FirstOrDefault();
        if (result == null)
        {
            return null;
        }
        return result;

    }
    [HttpPut]
    public models.User update([FromHeader(Name ="Authorization")]string token, [FromBody]User user)
    {
        if (token == null)
        {
            return null;
        }
        if (token.Split(" ")[0] != "Bearer"&& token.Split(" ")[1] != "user")
        {
            return null;
        }

        var userToUpdate = context.users.Where(u => u.ID == user.ID).FirstOrDefault();
        if (userToUpdate == null)
        {
            return null;
        }
        if(userToUpdate.password != "")
        {
            userToUpdate.password = hashPassword(user.password);
        }
        if(userToUpdate.userName != "")
        {
            userToUpdate.userName = user.userName;
        }
        if(userToUpdate.isGuest != user.isGuest)
        {
            userToUpdate.isGuest = user.isGuest;
        }

        context.SaveChanges();
        return userToUpdate;


    }
    [HttpPost]
    public string register([FromBody] models.User user)
    {
        var result = context.users.Where(u => u.userName == user.userName).Count();
        if (result == 1)
        {
            return "Username already exists";
        }
        user.password = hashPassword(user.password);
        context.users.Add(user);
        context.SaveChanges();
        return "User created";

    }
    [HttpPost("likepost")]
    public HttpResponseMessage likepost([FromHeader(Name = "Authorization")] string token,int id, string AttractionName)
    {
        if (token == null)
        {
            return null;
        }
        if (token.Split(" ")[0] != "Bearer" && token.Split(" ")[1] != "user")
        {
            return null;
        }
        var userToUpdate = context.users.Where(u => u.ID == id).FirstOrDefault();
        var attraction = context.attractions.Where(a => a.name == AttractionName).FirstOrDefault();
        if (userToUpdate == null)
        {
            System.Console.WriteLine("User not found");
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
        if (attraction == null)
        {
            System.Console.WriteLine("Attraction not found");
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
        userToUpdate.likedAttractions.Add(attraction);
        attraction.userLikes.Add(userToUpdate);
        context.SaveChanges();
        return new HttpResponseMessage(HttpStatusCode.OK);
    }
    [HttpDelete]
    public User delete([FromHeader(Name = "Authorization")] string token, int id)
    {
        if (token == null)
        {
            return null;
        }
        if (token.Split(" ")[0] != "Bearer" && token.Split(" ")[1] != "admin")
        {
            return null;
        }

        var user = context.users.Where(u => u.ID == id).FirstOrDefault();
        if (user == null)
        {
            return null;
        }
        context.users.Remove(user);
        context.SaveChanges();
        return user;


    }
}
public class userDataTransfer
{
    public string username { get; set; }
    public string password { get; set; }
}


