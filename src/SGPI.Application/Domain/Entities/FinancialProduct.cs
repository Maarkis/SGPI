using SGPI.Application.Common;
using SGPI.Domain.Entities.Abstract;

namespace SGPI.Application.Domain.Entities;

public class FinancialProduct : AuditableEntity
{
    private FinancialProduct(string name, string type, decimal value, DateTime maturityDate,
        double interestRate, string productCode)
    {
        Name = name;
        Type = type;
        Value = value;
        MaturityDate = maturityDate;
        InterestRate = interestRate;
        ProductCode = productCode;
    }

    public string Name { get; private set; }
    public string Type { get; private set; }
    public decimal Value { get; private set; }
    public DateTime MaturityDate { get; private set; }
    public double InterestRate { get; private set; }
    public string ProductCode { get; private set; }

    public void Edit(string? name, string? type, decimal? value, DateTime? maturityDate, double? interestRate)
    {
        Name = name ?? Name;
        Type = type ?? Type;
        Value = value ?? Value;
        MaturityDate = maturityDate ?? MaturityDate;
        InterestRate = interestRate ?? InterestRate;
    }

    public static FinancialProduct Create(string name, string type, decimal value, DateTime maturityDate,
        double interestRate, IProductCodeGenerator productCodeGenerator)
    {
        var productCode = productCodeGenerator.GenerateProductCode(name, type, DateOnly.FromDateTime(maturityDate));
        return new FinancialProduct(name, type, value, maturityDate, interestRate, productCode);
    }
}