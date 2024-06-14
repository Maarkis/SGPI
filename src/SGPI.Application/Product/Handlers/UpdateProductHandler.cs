using Ardalis.GuardClauses;
using MediatR;
using SGPI.Application.Infrastructure.Database;
using SGPI.Application.Product.Commands;

namespace SGPI.Application.Product.Handlers;

public class UpdateProductHandler(IFinancialProductRepository financialProductRepository) : IRequestHandler<UpdateProductCommand>
{
    
    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await financialProductRepository.GetByIdAsync(request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, product);
        
        product.Edit(request.Name, request.Type, request.Value, request.MaturityDate, request.InterestRate);
        
        financialProductRepository.UpdateAsync(product);
        await financialProductRepository.SaveAsync(cancellationToken);
    }
}