using MediatR;

namespace SGPI.Application.Product.Commands;

public record CreateProductCommand(string Name, string Type, decimal Value, DateTime MaturityDate, double InterestRate) : IRequest<Guid>;




