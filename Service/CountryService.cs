using System.Net.Http.Json;
using practicando.Models;

public class CountryService
{
    private readonly HttpClient _httpClient;

    public CountryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<(string nombreOficial, string banderaUrl, string region)> ObtenerInfoPais(string nombre)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<List<CountryInfo>>(
                $"https://restcountries.com/v3.1/name/{nombre}");

            if (response != null && response.Count > 0)
            {
                var pais = response[0];
                return (
                    pais.name?.official ?? "Desconocido",
                    pais.flags?.png ?? "",
                    pais.region ?? "Desconocida"
                );
            }
        }
        catch
        {
            // Puedes loguear el error si quieres
        }

        return ("Desconocido", "", "Desconocida");
    }
}
