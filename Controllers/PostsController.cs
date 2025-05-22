using Microsoft.AspNetCore.Mvc;
using practicando.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;

public class PostsController : Controller
{
    private readonly PostService _postService;
    private readonly HttpClient _httpClient;

    public PostsController(PostService postService, IHttpClientFactory httpClientFactory)
    {
        _postService = postService;
        _httpClient = httpClientFactory.CreateClient(); 
    }

    // GET: /Posts
    public async Task<IActionResult> Index()
    {
        var posts = await _postService.ObtenerPosts();
        return View(posts);
    }

    // GET: /Posts/Detalles/5
    public async Task<IActionResult> Detalles(int id)
    {
        try
        {
            var post = await _postService.ObtenerPost(id);
            if (post == null)
            {
                ViewBag.Error = "No se encontró el post.";
                return View("Error");
            }

            var autor = await _postService.ObtenerAutor(post.UserId);
            var comentarios = await _postService.ObtenerComentarios(id);

            ViewBag.Autor = autor;
            ViewBag.Comentarios = comentarios;
            return View(post);
        }
        catch (Exception ex)
        {
            ViewBag.Error = "Error al cargar el post o servicios externos. Intenta más tarde.";
            ViewBag.Exception = ex.ToString();
            return View("Error");
        }
    }
}
