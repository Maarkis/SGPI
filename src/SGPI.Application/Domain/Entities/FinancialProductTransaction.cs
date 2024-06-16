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

public sealed class FinancialProductDetail : Entity
{
    private FinancialProductDetail()
    {
    }

    private FinancialProductDetail(Guid financialProductId, string name, decimal value, string productCode)
    {
        FinancialProductId = financialProductId;
        Name = name;
        Value = value;
        ProductCode = productCode;
    }

    public Guid FinancialProductId { get; }
    public string Name { get; private set; }
    public decimal Value { get; private set; }
    public string ProductCode { get; private set; }

    public FinancialProductTransaction Transaction { get; }

    public static FinancialProductDetail Create(Guid financialProductId, string name, decimal value, string productCode)
    {
        return new FinancialProductDetail(financialProductId, name, value, productCode);
    }
}

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
        return new FinancialProductSale(product, clientId, quantity, purchasePrice, TransactionType.Sale);
    }
}

public enum TransactionType
{
    Buy = 1,
    Sale
}