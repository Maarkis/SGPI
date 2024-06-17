using System.Net.Http.Json;
using BenchmarkDotNet.Attributes;

namespace SGPI.Application.Benchmark;

public record Product(string Id);

[HtmlExporter]
public class GetAllProductsApiBenchmark
{
    private readonly ApiClient _apiClient = new();
    [Params(300, 400, 500)] public int IterationCount;

    [Benchmark]
    public async Task GetAllProductsAsync()
    {
        for (var i = 0; i < IterationCount; i++)
            await _apiClient.GetAllProducts();
    }

    [Benchmark]
    public async Task GetProductByIdAsync()
    {
        var ids = await GetProductsId();
        for (var i = 0; i < IterationCount; i++)
        {
            var id = ids[Random.Shared.Next(0, ids.Length)];
            await _apiClient.GetProductById(id);
        }
    }

    [Benchmark]
    public async Task GetExtractAsync()
    {
        const int idClient = 1;
        for (var i = 0; i < IterationCount; i++) await _apiClient.GetExtract(idClient);
    }


    private async Task<string[]> GetProductsId()
    {
        var response = await _apiClient.GetAllProducts();
        var products = await response.Content.ReadFromJsonAsync<List<Product>>() ?? [];
        return products.Select(x => x.Id).ToArray();
    }
}