using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGPI.Domain.Entities.Abstract;

namespace SGPI.Application.Infrastructure.Database.Maps.Abstract;

public abstract class AuditableEntityMap<TEntity> : EntityMap<TEntity>, IEntityTypeConfiguration<TEntity>
    where TEntity : AuditableEntity, new()
{
    public new void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);

        builder
            .Property(x => x.CreatedAt)
            .HasColumnName("create_at")
            .IsRequired();
        // Only created_at is working...
        // .HasDefaultValueSql("CURRENT_TIMESTAMP")
        // .ValueGeneratedOnAdd();

        builder
            .Property(x => x.UpdatedAt)
            .HasColumnName("update_at")
            .IsOptional();
        // .HasDefaultValueSql("CURRENT_TIMESTAMP")
        // .HasValueGenerator<UtcDateTimeValueGenerator>()
        // .ValueGeneratedOnUpdate();


        builder
            .Property(x => x.Enabled)
            .HasColumnName("enabled")
            .IsRequired();
    }
}