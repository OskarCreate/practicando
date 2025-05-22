using Microsoft.AspNetCore.Mvc;
using practicando.Data;
using practicando.Models;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class HistorialController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public HistorialController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> RegistrarPost([FromBody] HistorialPost post)
    {
        post.FechaConsulta = DateTime.Now;
        _context.HistorialPosts.Add(post);
        await _context.SaveChangesAsync();
        return Ok(post);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var historial = await _context.HistorialPosts.ToListAsync();
        return Ok(historial);
    }
}
