using MediatR;
using SGPI.Domain.Entities;

namespace SGPI.Application.Product.Commands;

public record GetByIdProductCommand(Guid id) : IRequest<FinancialProduct?>;
