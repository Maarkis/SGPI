using MediatR;
using SGPI.Domain.Entities;

namespace SGPI.Application.Product.Commands;

public record GetAllProductsCommand : IRequest<FinancialProduct[]>;