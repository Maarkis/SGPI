using SGPI.Application.Domain.Enum;

namespace SGPI.Application.Domain.Entities;

public sealed class FinancialProductPurchase : FinancialProductTransaction
{
    private FinancialProductPurchase(FinancialProductDetail productDetail, int clientId, int quantity,
        decimal purchasePrice,
        TransactionType transactionType)
        : base(productDetail, clientId, quantity, purchasePrice, transactionType)
    {
    }

    private FinancialProductPurchase()
    {
    }


    public static FinancialProductPurchase Create(FinancialProductDetail product, int clientId, int quantity,
        decimal purchasePrice
    )
    {
        return new FinancialProductPurchase(product, clientId, quantity, purchasePrice, TransactionType.Buy);
    }
}