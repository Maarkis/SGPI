using SGPI.Application.Domain.Enum;

namespace SGPI.Application.Endpoints;

public record FinancialProductTransactionResponse(
    Guid Id,
    int ClientId,
    int Quantity,
    decimal Price,
    TransactionType TransactionType,
    Guid FinancialProductId,
    string Name,
    string ProductCode);