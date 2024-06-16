using MediatR;
using SGPI.Application.Domain.Entities;
using SGPI.Application.Infrastructure.Database;
using SGPI.Application.Product.Commands;

namespace SGPI.Application.Product.Handlers;

public class ExtractHandler(IFinancialProductTransactionRepository financialProductTransactionRepository)
    : IRequestHandler<ExtractCommand, IEnumerable<FinancialProductTransaction>>
{
    public async Task<IEnumerable<FinancialProductTransaction>> Handle(ExtractCommand request,
        CancellationToken cancellationToken)
    {
        return await financialProductTransactionRepository
            .GetByClientIdAndTransactionTypeAsync(request.ClientId, request.TransactionType, cancellationToken);
    }
}