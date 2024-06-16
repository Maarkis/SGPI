using MediatR;
using SGPI.Application.Infrastructure.Database;
using SGPI.Application.Product.Commands;

namespace SGPI.Application.Product.Handlers;

public class DeleteProductHandler(IFinancialProductRepository financialProductRepository)
    : IRequestHandler<DeleteProductCommand>
{
    public Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        return financialProductRepository.RemoveAsync(request.Id, cancellationToken);
    }
}