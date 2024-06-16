using SGPI.Application.Domain.Enum;
using SGPI.Domain.Entities.Abstract;

namespace SGPI.Application.Domain.Entities;

public abstract class FinancialProductTransaction : AuditableEntity
{
    protected FinancialProductTransaction()
    {
    }

    protected FinancialProductTransaction(FinancialProductDetail productDetail, int clientId, int quantity,
        decimal price,
        TransactionType transactionType)
    {
        FinancialProductId = productDetail.FinancialProductId;
        ProductDetail = productDetail;
        Quantity = quantity;
        Price = price;
        TransactionType = transactionType;
        ClientId = clientId;
    }

    public FinancialProductDetail ProductDetail { get; private set; }
    public Guid FinancialProductId { get; private set; }
    public int Quantity { get; }
    public decimal Price { get; }
    public TransactionType TransactionType { get; private set; }
    public int ClientId { get; private set; }

    public decimal Total()
    {
        return Quantity * Price;
    }
}