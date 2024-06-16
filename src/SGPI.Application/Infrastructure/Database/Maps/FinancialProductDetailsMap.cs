using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGPI.Application.Domain.Entities;
using SGPI.Application.Infrastructure.Database.Maps.Abstract;

namespace SGPI.Application.Infrastructure.Database.Maps;

public class FinancialProductDetailsMap : EntityMap<FinancialProductDetail>,
    IEntityTypeConfiguration<FinancialProductDetail>
{
    public new void Configure(EntityTypeBuilder<FinancialProductDetail> builder)
    {
        base.Configure(builder);

        builder
            .Property(x => x.FinancialProductId)
            .HasColumnName("financial_product_id")
            .IsRequired();

        builder
            .Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(x => x.Value)
            .HasColumnName("value")
            .IsRequired();

        builder
            .Property(x => x.ProductCode)
            .HasColumnName("product_code")
            .HasMaxLength(30)
            .IsRequired();

        builder.ToTable("financial_product_details");
    }
}