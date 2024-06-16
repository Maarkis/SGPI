using MediatR;

namespace SGPI.Application.Product.Commands;

public record ProductPurchaseCommand(Guid FinancialProductId, int ClientId, int Quantity) : IRequest;