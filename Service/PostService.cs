using System.Net.Http;
using System.Text.Json;
using practicando.Models;

public class PostService
{
    private readonly HttpClient _httpClient;

    public PostService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Post>> ObtenerPosts()
    {
        var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");
        response.EnsureSuccessStatusCode();
        var contenido = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Post>>(contenido);
    }

    public async Task<Post> ObtenerPost(int id)
    {
        var response = await _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/posts/{id}");
        response.EnsureSuccessStatusCode();
        var contenido = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Post>(contenido);
    }

    public async Task<User> ObtenerAutor(int userId)
    {
        var response = await _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/users/{userId}");
        response.EnsureSuccessStatusCode();
        var contenido = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<User>(contenido);
    }

    public async Task<List<Comment>> ObtenerComentarios(int postId)
    {
        var response = await _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/comments?postId={postId}");
        response.EnsureSuccessStatusCode();
        var contenido = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Comment>>(contenido);
    }
}
