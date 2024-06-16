using MediatR;
using SGPI.Application.Domain.Entities;
using SGPI.Application.Infrastructure.Database;
using SGPI.Application.Product.Commands;

namespace SGPI.Application.Product.Handlers;

public class GetByIdProductHandler(IFinancialProductRepository repository)
    : IRequestHandler<GetByIdProductCommand, FinancialProduct?>
{
    public Task<FinancialProduct?> Handle(GetByIdProductCommand request, CancellationToken cancellationToken)
    {
        return repository.GetByIdAsync(request.id, cancellationToken);
    }
}