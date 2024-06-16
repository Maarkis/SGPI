using MediatR;
using Microsoft.EntityFrameworkCore;
using SGPI.Application.Endpoints;
using SGPI.Application.Infrastructure.Database;
using SGPI.Application.Product.Commands;

namespace SGPI.Application.Product.Handlers;

public class GetByIdProductHandler(IAppDatabaseContext context)
    : IRequestHandler<GetByIdProductCommand, FinancialProductResponse?>
{
    public async Task<FinancialProductResponse?> Handle(GetByIdProductCommand request,
        CancellationToken cancellationToken)
    {
        return await context.FinancialProducts
            .Where(x => x.Id == request.id)
            .Select(x =>
                new FinancialProductResponse(
                    x.Id, x.Name, x.Type, x.Value, x.MaturityDate, x.InterestRate, x.ProductCode))
            .FirstOrDefaultAsync(cancellationToken);
    }
}