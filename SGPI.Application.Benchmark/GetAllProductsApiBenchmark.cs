using System.Net.Http.Json;
using BenchmarkDotNet.Attributes;

namespace SGPI.Application.Benchmark;

public record Product(string Id);

[HtmlExporter]
public class GetAllProductsApiBenchmark
{
    private readonly ProductClient _productClient = new();
    [Params(100, 200)] public int IterationCount;

    [Benchmark]
    public async Task GetAllProductsAsync()
    {
        for (var i = 0; i < IterationCount; i++)
            await _productClient.GetAllProducts();
    }

    [Benchmark]
    public async Task GetProductByIdAsync()
    {
        var ids = await GetProductsId();
        for (var i = 0; i < IterationCount; i++)
        {
            var id = ids[Random.Shared.Next(0, ids.Length)];
            await _productClient.GetProductById(id);
        }
    }


    private async Task<string[]> GetProductsId()
    {
        var response = await _productClient.GetAllProducts();
        var products = await response.Content.ReadFromJsonAsync<List<Product>>() ?? [];
        return products.Select(x => x.Id).ToArray();
    }
}