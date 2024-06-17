using System.Net.Http.Headers;

namespace SGPI.Application.Benchmark;

public class ApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("http://localhost:5042");
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<HttpResponseMessage> GetAllProducts()
    {
        var response = await _httpClient.GetAsync("api/products");
        response.EnsureSuccessStatusCode();

        return response;
    }

    public async Task<HttpResponseMessage> GetProductById(string id)
    {
        var response = await _httpClient.GetAsync($"api/products/{id}");
        response.EnsureSuccessStatusCode();

        return response;
    }

    public async Task<HttpResponseMessage> GetExtract(int idClient)
    {
        var response = await _httpClient.GetAsync($"api/extract/{idClient}");
        response.EnsureSuccessStatusCode();

        return response;
    }
}