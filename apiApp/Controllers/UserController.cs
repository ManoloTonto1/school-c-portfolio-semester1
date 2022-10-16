using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace apiApp.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    models.DatabaseContext context = new models.DatabaseContext();
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<models.User> Get(int UserId)
    {
        return await Task.Run(() => context.users.Where(g => g.ID == UserId).First());

    }
    [HttpGet("all")]
    public async Task<IEnumerable<models.User>> GetAll(int limit = 10, int offset=0)
    {
        return await Task.Run(() => context.users.Skip(offset).Take(limit).ToList());
    }
    [HttpPost("login")]
    public models.User login([FromBody] userDataTransfer user)
    {
        var result = context.users.Where(u => u.userName == user.username).FirstOrDefault();
        if (result == null)
        {
            return null;
        }
        return result;

    }
    [HttpPost("register")]
    public string register([FromBody] models.User user)
    {
        var result = context.users.Where(u => u.userName == user.userName).Count();
        if (result == 1)
        {
            return "Username already exists";
        }
        context.users.Add(user);
        context.SaveChanges();
        return "User created";

    }
}
public class userDataTransfer
{
    public string username { get; set; }
    public string password { get; set; }
}


