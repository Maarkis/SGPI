namespace SGPI.Application.Endpoints;

public record UpdateProductRequest(string? Name, string? Type, decimal? Value, DateTime? MaturityDate, double? InterestRate);