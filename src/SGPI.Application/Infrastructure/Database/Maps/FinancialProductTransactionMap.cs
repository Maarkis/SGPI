using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGPI.Application.Domain.Entities;
using SGPI.Application.Infrastructure.Database.Maps.Abstract;

namespace SGPI.Application.Infrastructure.Database.Maps;

public class FinancialProductTransactionMap : AuditableEntityMap<FinancialProductTransaction>,
    IEntityTypeConfiguration<FinancialProductTransaction>
{
    public new void Configure(EntityTypeBuilder<FinancialProductTransaction> builder)
    {
        base.Configure(builder);

        builder
            .Property(x => x.Quantity)
            .HasColumnName("quantity")
            .IsRequired();

        builder
            .Property(x => x.ClientId)
            .HasColumnName("client_id")
            .IsRequired();

        builder
            .Property(x => x.FinancialProductId)
            .HasColumnName("product_detail_id")
            .IsRequired();

        builder
            .Property(x => x.Price)
            .HasColumnName("price")
            .IsRequired();

        builder
            .Property(x => x.TransactionType)
            .HasColumnName("transaction_type")
            .HasMaxLength(10)
            .IsRequired();

        builder.HasOne(x => x.ProductDetail)
            .WithOne(x => x.Transaction)
            .HasForeignKey<FinancialProductTransaction>(x => x.Id);

        builder
            .HasDiscriminator<TransactionType>("TransactionType")
            .HasValue<FinancialProductPurchase>(TransactionType.Buy)
            .HasValue<FinancialProductSale>(TransactionType.Sale);


        builder.ToTable("financial_product_transactions");
    }
}