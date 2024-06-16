namespace SGPI.NotifyInvest.Job.Models;

public record FinancialProduct
{
    public required string Name { get; init; }
    public required DateTime MaturityDate { get; init; }
    public required string ProductCode { get; init; }
}