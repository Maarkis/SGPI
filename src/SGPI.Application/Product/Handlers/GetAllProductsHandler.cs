using MediatR;
using SGPI.Application.Domain.Entities;
using SGPI.Application.Infrastructure.Database;
using SGPI.Application.Product.Commands;
using SGPI.Domain.Entities;

namespace SGPI.Application.Product.Handlers;

public class GetAllProductsHandler(IFinancialProductRepository repository)
    : IRequestHandler<GetAllProductsCommand, FinancialProduct[]>
{
    public async Task<FinancialProduct[]> Handle(GetAllProductsCommand request, CancellationToken cancellationToken)
    {
        return await repository.GetAllAsync(cancellationToken);
    }
}