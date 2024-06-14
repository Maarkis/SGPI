using System.Net.Http.Json;
using BenchmarkDotNet.Attributes;

namespace SGPI.Application.Benchmark;

public record Product(
    string Name,
    string Type,
    int Value,
    string MaturityDate,
    int InterestRate,
    string ProductCode,
    string CreatedAt,
    object UpdateAt,
    bool Enabled,
    bool IsDisabled,
    string Id
);



[HtmlExporter]
public class GetAllProductsApiBenchmark
{
    [Params(100, 200)] public int IterationCount;

    private readonly ProductClient _productClient = new();
    
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

