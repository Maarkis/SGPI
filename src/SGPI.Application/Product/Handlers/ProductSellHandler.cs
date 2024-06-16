using Ardalis.GuardClauses;
using MediatR;
using SGPI.Application.Domain.Entities;
using SGPI.Application.Infrastructure.Database;
using SGPI.Application.Product.Commands;

namespace SGPI.Application.Product.Handlers;

public class ProductSellHandler(
    IFinancialProductTransactionRepository financialProductTransactionRepository,
    IFinancialProductRepository financialProductRepository)
    : IRequestHandler<ProductSellCommand>
{
    public async Task Handle(ProductSellCommand request, CancellationToken cancellationToken)
    {
        var product = await financialProductRepository.GetByIdAsync(request.FinancialProductId, cancellationToken);
        // TODO: Either pattern ?
        Guard.Against.NotFound("Product", product, $"Product with id: {request.FinancialProductId}");

        var productDetail = FinancialProductDetail
            .Create(product.Id, product.Name, product.Value, product.ProductCode);
        var financialProductPurchase = FinancialProductSale
            .Create(productDetail, request.ClientId, request.Quantity, product.Value);

        await financialProductTransactionRepository.AddAsync(financialProductPurchase, cancellationToken);
        await financialProductTransactionRepository.SaveAsync(cancellationToken);
    }
}