using MediatR;
using SGPI.Application.Domain.Enum;
using SGPI.Application.Endpoints;

namespace SGPI.Application.Product.Commands;

public record ExtractCommand(int ClientId, TransactionType? TransactionType)
    : IRequest<FinancialProductTransactionResponse[]>;