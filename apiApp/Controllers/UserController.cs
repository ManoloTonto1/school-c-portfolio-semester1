using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using apiApp.models;
using System.Net;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;

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
    private readonly DatabaseContext context = new DatabaseContext();
    private readonly UserManager<User> _userManager;
    private readonly UserManager<User> _signInManager;
    private readonly JWTTools jwtTools = new JWTTools();
    public UserController(UserManager<User> userManager)
    {
        _userManager = userManager;
        _signInManager = userManager;
    }



    [HttpGet("{id}")]
    public async Task<ActionResult<User>> Get([FromHeader(Name = "Authorization")] string token, int id)
    {
        var (tokenValid, isAdmin) = jwtTools.checkTokenAndRole(token);
        if (!tokenValid && !isAdmin)
        {
            return Unauthorized();
        }
        if (context.users == null)
        {
            return NotFound();
        }
        var user = await context.users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;

    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAll([FromHeader(Name = "Authorization")] string token, int limit = 10, int offset = 0)
    {
        var (tokenValid, isAdmin) = jwtTools.checkTokenAndRole(token);
        if (!tokenValid || !isAdmin)
        {
            return Unauthorized();
        }
        if (context.users == null)
        {
            return NotFound();
        }
        return await context.users.ToListAsync();
    }
    [HttpPost]
    public async Task<ActionResult> Register([FromBody] User user)
    {
        if (user.password == null || user.UserName == null)
        {
            return BadRequest();
        }


        var res = await _userManager.CreateAsync(user, hashPassword(user.password));
        return !res.Succeeded ? new BadRequestObjectResult(res) : StatusCode(201);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] userDataTransfer user)
    {
        var _user = await _userManager.FindByNameAsync(user.username);
        if (_user == null)
        {
            return Unauthorized();
        }

        if (await _userManager.CheckPasswordAsync(_user, hashPassword(user.password)))
        {
            if (_user.isGuest == null)
            {
                return BadRequest();
            }
            var _role = (bool)_user.isGuest ? "guest" : "admin";
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"));

            var signingCredentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, _user.UserName),
                    new Claim(ClaimTypes.Role, _role),
                    };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));
            var tokenOptions = new JwtSecurityToken
            (
                issuer: "https://localhost:7047",
                audience: "https://localhost:7047",
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signingCredentials
            );
            return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(tokenOptions) });
        }

        return Unauthorized();
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<User>> update([FromHeader(Name = "Authorization")] string token, int? id, [FromBody] User user)
    {

        var (tokenValid, isAdmin) = jwtTools.checkTokenAndRole(token);
        if (!tokenValid || !isAdmin)
        {
            return Unauthorized();
        }
        if (id.ToString() != user.Id)
        {
            return BadRequest();
        }

        context.Entry(user).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpPost("likepost")]
    public async Task<IActionResult> likepost([FromHeader(Name = "Authorization")] string token, string attractionName)
    {
        var isAllowed = jwtTools.checkTokenAndRole(token);
        if (!isAllowed.Item1)
        {
            return Unauthorized();
        }
        var userToUpdate = _userManager.FindByNameAsync(jwtTools.getUserFromToken(token)).Result;
        if (userToUpdate == null)
        {
            return NotFound("User not found");
        }
        var attraction = await context.attractions.Where(a => a.name == attractionName).FirstOrDefaultAsync();
        if (attraction == null)
        {
            return NotFound("User not found");
        }
        context.users.Where(u => u == userToUpdate).Select(u => u.likedAttractions).FirstOrDefault().Add(attraction);
        await context.SaveChangesAsync();

        return Ok(attraction);
    }
    [HttpDelete]
    public async Task<ActionResult<User>> delete([FromHeader(Name = "Authorization")] string token, int id)
    {
        var isAllowed = jwtTools.checkTokenAndRole(token);
        if (!isAllowed.Item1)
        {
            return Unauthorized();
        }
        if (context.users == null)
        {
            return NotFound();
        }
        var user = await context.users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        context.users.Remove(user);
        await context.SaveChangesAsync();

        return NoContent();
    }
    private bool UserExists(int? id)
    {
        return (context.users?.Any(e => e.Id == id.ToString())).GetValueOrDefault();
    }
}
public class userDataTransfer
{
    [Required(ErrorMessage = "Username is required")]
    public string? username { get; init; }
    [Required(ErrorMessage = "password is required")]
    public string? password { get; init; }
}



