using MediatR;
using SGPI.Application.Common;
using SGPI.Application.Domain.Entities;
using SGPI.Application.Infrastructure.Database;
using SGPI.Application.Product.Commands;
using SGPI.Domain.Entities;

namespace SGPI.Application.Product.Handlers;

public class CreateProductHandler(IFinancialProductRepository repository, IProductCodeGenerator productCodeGenerator)
    : IRequestHandler<CreateProductCommand, Guid>
{
    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var financialProduct = FinancialProduct
            .Create(
                request.Name, request.Type, request.Value,
                request.MaturityDate, request.InterestRate, productCodeGenerator);
        var id = await repository.AddAsync(financialProduct, cancellationToken);
        await repository.SaveAsync(cancellationToken);
        return id;
    }
}