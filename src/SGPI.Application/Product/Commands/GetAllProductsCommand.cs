using MediatR;
using SGPI.Application.Domain.Entities;

namespace SGPI.Application.Product.Commands;

public record GetAllProductsCommand : IRequest<FinancialProduct[]>;