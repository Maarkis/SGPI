using SGPI.Application.Domain.Entities;

namespace SGPI.Application.Endpoints;

public record FinancialProductResponse(
    Guid Id,
    string Name,
    string Type,
    decimal Value,
    DateTime MaturityDate,
    double InterestRate,
    string ProductCode)
{
    public static implicit operator FinancialProductResponse(FinancialProduct product)
    {
        return new FinancialProductResponse(product.Id, product.Name, product.Type, product.Value, product.MaturityDate,
            product.InterestRate,
            product.ProductCode);
    }
}