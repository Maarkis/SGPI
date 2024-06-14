using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SGPI.Application.Infrastructure.Database;

public static class PropertyBuilderExtensions
{
    public static PropertyBuilder<TProperty> IsOptional<TProperty>(this PropertyBuilder<TProperty> propertyBuilder)
    {
        propertyBuilder.IsRequired(false);
        return propertyBuilder;
    }
}