namespace SGPI.NotifyInvest.Job.Models;

public record FinancialProduct
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Type { get; init; }
    public required decimal Value { get; init; }
    public required DateTime MaturityDate { get; init; }
    public required double InterestRate { get; init; }
    public required string ProductCode { get; init; }
}