using MediatR;
using SGPI.Application.Endpoints;

namespace SGPI.Application.Product.Commands;

public record GetAllProductsCommand : IRequest<FinancialProductResponse[]>;