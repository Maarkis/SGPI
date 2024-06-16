using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGPI.Application.Domain.Entities;
using SGPI.Application.Infrastructure;
using SGPI.Application.Product.Commands;

namespace SGPI.Application.Endpoints;

public class ExtractEndpoint : EndpointGroupBase
{
    public override string Name => "Extract";
    public override string[] Tags => ["Extract"];

    public override void Map(WebApplication app)
    {
        app
            .MapGroup(this)
            .MapGet(Extract, "/{clientId:int}");
    }


    private static async Task<IResult> Extract([FromServices] ISender sender, int clientId,
        [FromQuery] TransactionType? transactionType)
    {
        var transactions = await sender.Send(new ExtractCommand(clientId, transactionType));
        return Results.Ok(transactions);
    }
}