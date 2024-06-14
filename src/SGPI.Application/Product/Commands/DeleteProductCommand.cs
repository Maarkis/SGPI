using MediatR;

namespace SGPI.Application.Product.Commands;

public record DeleteProductCommand(Guid Id) : IRequest;