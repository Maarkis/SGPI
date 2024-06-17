using SGPI.Domain.Entities.Abstract;

namespace SGPI.Application.Domain.Entities;

public sealed class FinancialProductDetail : Entity
{
    private FinancialProductDetail()
    {
    }

    private FinancialProductDetail(Guid financialProductId, string name, decimal value, string productCode)
    {
        FinancialProductId = financialProductId;
        Name = name;
        Value = value;
        ProductCode = productCode;
    }

    public Guid FinancialProductId { get; }
    public string Name { get; private set; }
    public decimal Value { get; private set; }
    public string ProductCode { get; private set; }

    public FinancialProductTransaction Transaction { get; }

    public static FinancialProductDetail Create(Guid financialProductId, string name, decimal value, string productCode)
    {
        return new FinancialProductDetail(financialProductId, name, value, productCode);
    }
}