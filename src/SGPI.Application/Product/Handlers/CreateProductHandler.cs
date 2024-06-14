using MediatR;
using SGPI.Application.Common;
using SGPI.Application.Infrastructure.Database;
using SGPI.Application.Product.Commands;
using SGPI.Domain.Entities;

namespace SGPI.Application.Product.Handlers;

public class CreateProductHandler(IFinancialProductRepository repository, IProductCodeGenerator productCodeGenerator) : IRequestHandler<CreateProductCommand, Guid>
{
    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var productCode = productCodeGenerator.GenerateProductCode(request.Name, request.Type, DateOnly.FromDateTime(request.MaturityDate));
        var financialProduct = FinancialProduct.Create(request.Name, request.Type, request.Value, request.MaturityDate, request.InterestRate, productCode);
        var id = await repository.AddAsync(financialProduct, cancellationToken);
        await repository.SaveAsync(cancellationToken);
        return id;
    }
} 