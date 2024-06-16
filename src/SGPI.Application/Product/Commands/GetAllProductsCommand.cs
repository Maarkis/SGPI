using MediatR;
using SGPI.Application.Domain.Entities;
using SGPI.Domain.Entities;

namespace SGPI.Application.Product.Commands;

public record GetAllProductsCommand : IRequest<FinancialProduct[]>;