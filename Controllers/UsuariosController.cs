using Microsoft.AspNetCore.Mvc;
using practicando.Data;
using practicando.Models;
using Microsoft.EntityFrameworkCore;


public class UsuariosController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly CountryService _countryService;

    public UsuariosController(ApplicationDbContext context, CountryService countryService)
    {
        _context = context;
        _countryService = countryService;
    }

    public async Task<IActionResult> Index()
{
    var usuarios = await _context.Usuarios.ToListAsync(); //
    var enrichedUsuarios = new List<(Usuario, string nombreOficial, string bandera, string region)>();

    foreach (var usuario in usuarios)
    {
        var (nombreOficial, bandera, region) = await _countryService.ObtenerInfoPais(usuario.Pais);
        enrichedUsuarios.Add((usuario, nombreOficial, bandera, region));
    }

    return View(enrichedUsuarios);
}

    public IActionResult Crear()
    {
    return View();
    }

    [HttpPost]
    public async Task<IActionResult> Crear(Usuario usuario)
    {
        if (!ModelState.IsValid)
            return View(usuario);

        var (nombreOficial, bandera, region) = await _countryService.ObtenerInfoPais(usuario.Pais);

        if (nombreOficial == "Desconocido")
        {
            ModelState.AddModelError("Pais", "El país ingresado no es válido.");
            return View(usuario);
        }

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
