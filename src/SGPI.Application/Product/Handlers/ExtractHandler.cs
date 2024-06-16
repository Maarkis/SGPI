using MediatR;
using Microsoft.EntityFrameworkCore;
using SGPI.Application.Endpoints;
using SGPI.Application.Infrastructure.Database;
using SGPI.Application.Product.Commands;

namespace SGPI.Application.Product.Handlers;

public class ExtractHandler(IAppDatabaseContext context)
    : IRequestHandler<ExtractCommand, FinancialProductTransactionResponse[]>
{
    public async Task<FinancialProductTransactionResponse[]> Handle(ExtractCommand request,
        CancellationToken cancellationToken)
    {
        var query = context
            .FinancialProductTransactions
            .Where(x => x.ClientId == request.ClientId);

        if (request.TransactionType is not null)
            query = query.Where(x => x.TransactionType == request.TransactionType);

        return await query
            .Select(x => new FinancialProductTransactionResponse(x.Id, x.ClientId, x.Quantity, x.Price,
                x.TransactionType, x.FinancialProductId, x.ProductDetail.Name, x.ProductDetail.ProductCode))
            .ToArrayAsync(cancellationToken);
    }
}