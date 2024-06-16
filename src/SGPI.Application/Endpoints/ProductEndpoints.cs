using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGPI.Application.Infrastructure;
using SGPI.Application.Product.Commands;

namespace SGPI.Application.Endpoints;

public class ProductEndpoints : EndpointGroupBase
{
    public override string Name => "Products";
    public override string[] Tags => ["Products"];

    public override void Map(WebApplication app)
    {
        app
            .MapGroup(this)
            .MapPost(CreateProduct)
            .MapGet(GetProductList)
            .MapGet(GetProduct, "/{id:guid}")
            .MapPut(UpdateProduct, "/{id:guid}")
            .MapDelete(DeleteProduct, "/{id:guid}");
    }

    private static async Task<IResult> GetProductList([FromServices] ISender sender)
    {
        var result = await sender.Send(new GetAllProductsCommand());
        return Results.Ok(result);
    }

    private static async Task<IResult> CreateProduct([FromServices] ISender sender, CreateProductCommand command)
    {
        var result = await sender.Send(command);
        return Results.CreatedAtRoute(nameof(GetProduct), new { id = result });
    }

    private static async Task<IResult> GetProduct([FromServices] ISender sender, Guid id)
    {
        if (id == Guid.Empty)
            return Results.BadRequest();

        var result = await sender.Send(new GetByIdProductCommand(id));
        return result is null ? Results.NotFound() : Results.Ok(result);
    }

    private static async Task<IResult> UpdateProduct([FromServices] ISender sender, Guid id,
        UpdateProductRequest request)
    {
        if (id == Guid.Empty)
            return Results.BadRequest();

        await sender.Send(new UpdateProductCommand(id, request.Name, request.Type, request.Value, request.MaturityDate,
            request.InterestRate));
        return Results.NoContent();
    }

    private static async Task<IResult> DeleteProduct([FromServices] ISender sender, Guid id)
    {
        if (id == Guid.Empty)
            return Results.BadRequest();

        await sender.Send(new DeleteProductCommand(id));
        return Results.NoContent();
    }
}