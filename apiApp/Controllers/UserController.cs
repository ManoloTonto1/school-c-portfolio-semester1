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
    public async Task<models.Guest> Get(int UserId)
    {
        return await Task.Run(() => context.guests.Where(g => g.ID == UserId).First());

    }
    [HttpGet("all")]
    public async Task<IEnumerable<models.Guest>> GetAll(int limit = 10, int offset = 0)
    {
        return await Task.Run(() => context.guests.ToList().Take(limit).Skip(offset));
    }
}
