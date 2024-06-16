using MediatR;
using SGPI.Application.Domain.Entities;

namespace SGPI.Application.Product.Commands;

public record ExtractCommand(int ClientId, TransactionType? TransactionType)
    : IRequest<IEnumerable<FinancialProductTransaction>>;