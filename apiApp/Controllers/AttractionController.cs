using Microsoft.AspNetCore.Mvc;
using apiApp.models;
using Microsoft.EntityFrameworkCore;

namespace apiApp.Controllers;

[ApiController]
[Route("[controller]")]
public class AttractionController : ControllerBase
{
    private readonly JWTTools jwtTools = new JWTTools();
    private readonly DatabaseContext context = new DatabaseContext();
    private readonly ILogger<AttractionController> _logger;

    public AttractionController(ILogger<AttractionController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Attraction>> Get([FromHeader(Name = "Authorization")] string token, int id)
    {
        var _ = jwtTools.checkTokenAndRole(token);
        if (!_.Item1)
        {
            return Unauthorized();
        }
        var res = await context.attractions.Where(g => g.ID == id).FirstOrDefaultAsync();
        if (res == null)
        {
            return NotFound();
        }
        return res;


    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Attraction>>> GetAll([FromHeader(Name = "Authorization")] string token, int limit = 10, int offset = 0)
    {
        var (tokenValid, isAdmin) = jwtTools.checkTokenAndRole(token);
        if (!tokenValid)
        {
            return Unauthorized();
        }
        var res = await context.attractions.Skip(offset).Take(limit).ToListAsync();
        if (res == null)
        {
            return NotFound();
        }
        return res;
    }
    [HttpPost]
    public async Task<ActionResult<string>> register([FromHeader(Name = "Authorization")] string token, [FromBody] Attraction attraction)
    {
        var (tokenValid, isAdmin) = jwtTools.checkTokenAndRole(token);
        if (!tokenValid || !isAdmin)
        {
            return Unauthorized();
        }
        var result = context.attractions.Where(u => u.name == attraction.name).Count();
        if (result >= 1)
        {
            return BadRequest("attractionname already exists");
        }
        await context.attractions.AddAsync(attraction);
        await context.SaveChangesAsync();
        return Ok("attraction created");

    }
    [HttpPut("{id}")]
    public async Task<ActionResult<Attraction>> update([FromHeader(Name = "Authorization")] string token, int? id, [FromBody] Attraction attraction)
    {
        var (tokenValid, isAdmin) = jwtTools.checkTokenAndRole(token);
        if (!tokenValid || !isAdmin)
        {
            return Unauthorized();
        }
        if (id != attraction.ID)
        {
            return BadRequest();
        }

        context.Entry(attraction).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AttractionExists(id))
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
    [HttpDelete]
    public async Task<ActionResult<Attraction>> delete([FromHeader(Name = "Authorization")] string token, int id)
    {
        var isAllowed = jwtTools.checkTokenAndRole(token);
        if (!isAllowed.Item1)
        {
            return Unauthorized();
        }
        if (context.attractions == null)
        {
            return NotFound();
        }
        var attraction = await context.attractions.FindAsync(id);
        if (attraction == null)
        {
            return NotFound();
        }

        context.attractions.Remove(attraction);
        await context.SaveChangesAsync();

        return NoContent();


    }
    private bool AttractionExists(int? id)
    {
        return (context.attractions?.Any(e => e.ID == id)).GetValueOrDefault();
    }
}