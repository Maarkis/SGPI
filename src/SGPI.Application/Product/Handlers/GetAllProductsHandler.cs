using MediatR;
using Microsoft.EntityFrameworkCore;
using SGPI.Application.Endpoints;
using SGPI.Application.Infrastructure.Database;
using SGPI.Application.Product.Commands;

namespace SGPI.Application.Product.Handlers;

public class GetAllProductsHandler(IAppDatabaseContext context)
    : IRequestHandler<GetAllProductsCommand, FinancialProductResponse[]>
{
    public async Task<FinancialProductResponse[]> Handle(GetAllProductsCommand request,
        CancellationToken cancellationToken)
    {
        return await context
            .FinancialProducts
            .Select(x =>
                new FinancialProductResponse(x.Id, x.Name, x.Type, x.Value, x.MaturityDate, x.InterestRate,
                    x.ProductCode))
            .ToArrayAsync(cancellationToken);
    }
}