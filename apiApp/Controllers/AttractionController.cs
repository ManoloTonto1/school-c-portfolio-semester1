using Microsoft.AspNetCore.Mvc;
using apiApp.models;
namespace apiApp.Controllers;

[ApiController]
[Route("[controller]")]
public class AttractionController : ControllerBase{
    models.DatabaseContext context = new models.DatabaseContext();
    private readonly ILogger<AttractionController> _logger;

    public AttractionController(ILogger<AttractionController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<Attraction> Get(int id)
    {
        return await Task.Run(() => context.attractions.Where(g => g.ID == id).First());

    }
    [HttpGet("all")]
    public async Task<IEnumerable<Attraction>> GetAll(int limit = 10, int offset = 0)
    {
        return await Task.Run(() => context.attractions.Skip(offset).Take(limit).ToList());
    }
    [HttpPost]
    public string register([FromHeader(Name = "Authorization")] string token,[FromBody] Attraction attraction)
    {
        if (token == null)
        {
            return null;
        }
        if (token.Split(" ")[0] != "Bearer" && token.Split(" ")[1] != "admin")
        {
            return null;
        }

        var result = context.attractions.Where(u => u.name == attraction.name).Count();
        if (result >= 1)
        {
            return "attractionname already exists";
        }
        context.attractions.Add(attraction);
        context.SaveChanges();
        return "attraction created";

    }
    [HttpPut]
    public Attraction update([FromHeader(Name = "Authorization")] string token, Attraction attraction)
    {
        if (token == null)
        {
            return null;
        }
        if (token.Split(" ")[0] != "Bearer"&& token.Split(" ")[1] != "admin")
        {
            return null;
        }

        var attractionToUpdate = context.attractions.Where(u => u.ID == attraction.ID).FirstOrDefault();
        if (attractionToUpdate == null)
        {
            return null;
        }
        if (attractionToUpdate.name != "")
        {
            attractionToUpdate.name = attraction.name;
        }
        if (attractionToUpdate.fearLevel != attraction.fearLevel)
        {
            attractionToUpdate.fearLevel = attraction.fearLevel;
        }
        context.SaveChanges();
        return attractionToUpdate;


    }
    [HttpDelete]
    public Attraction delete([FromHeader(Name = "Authorization")] string token, int id)
    {
        if (token == null)
        {
            return null;
        }
        if (token.Split(" ")[0] != "Bearer"&& token.Split(" ")[1] != "admin")
        {
            return null;
        }

        var attraction = context.attractions.Where(u => u.ID == id).FirstOrDefault();
        if (attraction == null)
        {
            return null;
        }
        context.attractions.Remove(attraction);
        context.SaveChanges();
        return attraction;


    }
}