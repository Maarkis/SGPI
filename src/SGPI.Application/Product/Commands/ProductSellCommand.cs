using MediatR;

namespace SGPI.Application.Product.Commands;

public record ProductSellCommand(Guid FinancialProductId, int ClientId, int Quantity) : IRequest;