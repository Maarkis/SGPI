using MediatR;

namespace SGPI.Application.Product.Commands;

public record UpdateProductCommand(Guid Id, string? Name, string? Type, decimal? Value, DateTime? MaturityDate, double? InterestRate) : IRequest;