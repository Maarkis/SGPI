using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGPI.Application.Domain.Entities;
using SGPI.Application.Infrastructure.Database.Maps.Abstract;

namespace SGPI.Application.Infrastructure.Database.Maps;

public class FinancialProductMap : AuditableEntityMap<FinancialProduct>, IEntityTypeConfiguration<FinancialProduct>
{
    public new void Configure(EntityTypeBuilder<FinancialProduct> builder)
    {
        base.Configure(builder);

        builder
            .Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(x => x.Type)
            .HasColumnName("type")
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(x => x.Value)
            .HasColumnName("value")
            .IsRequired();

        builder
            .Property(x => x.MaturityDate)
            .HasColumnName("maturity_date")
            .IsRequired();

        builder
            .Property(x => x.InterestRate)
            .HasColumnName("interest_rate")
            .IsRequired();

        builder
            .Property(x => x.ProductCode)
            .HasColumnName("product_code")
            .HasMaxLength(30)
            .IsRequired();

        builder
            .HasIndex(index => index.ProductCode);

        builder.ToTable("financial_products");
    }
}