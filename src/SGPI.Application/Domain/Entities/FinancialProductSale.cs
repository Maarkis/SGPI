using SGPI.Application.Domain.Enum;

namespace SGPI.Application.Domain.Entities;

public sealed class FinancialProductSale : FinancialProductTransaction
{
    private FinancialProductSale(FinancialProductDetail productDetail, int clientId, int quantity,
        decimal purchasePrice,
        TransactionType transactionType)
        : base(productDetail, clientId, quantity, purchasePrice, transactionType)
    {
    }

    private FinancialProductSale()
    {
    }

    public static FinancialProductSale Create(FinancialProductDetail product, int clientId, int quantity,
        decimal purchasePrice)
    {
        return new FinancialProductSale(product, clientId, quantity, purchasePrice, TransactionType.Sell);
    }
}