using MediatR;
using SGPI.Application.Infrastructure.Database;
using SGPI.Application.Product.Commands;
using SGPI.Domain.Entities;

namespace SGPI.Application.Product.Handlers;

public class GetByIdProductHandler(IFinancialProductRepository repository) : IRequestHandler<GetByIdProductCommand, FinancialProduct?>
{
    public Task<FinancialProduct?> Handle(GetByIdProductCommand request, CancellationToken cancellationToken) => 
        repository.GetByIdAsync(request.id, cancellationToken);
} 