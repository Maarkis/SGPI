using SGPI.Domain.Entities.Abstract;

namespace SGPI.Application.Domain.Entities;

public class FinancialProduct : AuditableEntity
{
    public string Name { get; private set; } = default!;
    public string Type { get; private set; } = default!;
    public decimal Value { get; private set; }
    public DateTime MaturityDate { get; private set; }
    public double InterestRate { get; private set; }
    public string ProductCode { get; private set; } = default!;


    public void Edit(string? name, string? type, decimal? value, DateTime? maturityDate, double? interestRate)
    {
        Name = name ?? Name;
        Type = type ?? Type;
        Value = value ?? Value;
        MaturityDate = maturityDate ?? MaturityDate;
        InterestRate = interestRate ?? InterestRate;
    }

    public static FinancialProduct Create(string name, string type, decimal value, DateTime maturityDate,
        double interestRate, string productCode)
    {
        return new FinancialProduct
        {
            Id = Guid.NewGuid(),
            Name = name,
            Type = type,
            Value = value,
            MaturityDate = maturityDate,
            InterestRate = interestRate,
            ProductCode = productCode
        };
    }
}