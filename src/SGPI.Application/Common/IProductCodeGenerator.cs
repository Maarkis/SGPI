namespace SGPI.Application.Common;

public interface IProductCodeGenerator
{
    string GenerateProductCode(string name, string type, DateOnly date);
}

public class ProductCodeGenerator : IProductCodeGenerator
{
    public string GenerateProductCode(string name, string type, DateOnly date)
    {
        ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
        ArgumentException.ThrowIfNullOrEmpty(type, nameof(type));
        ArgumentNullException.ThrowIfNull(date, nameof(date));

        var nameInitials = name
            .Trim()
            .Split(' ')
            .Aggregate(string.Empty, (current, word) => current + word[0])
            .ToUpperInvariant();
        var typeInitials = type
            .Trim()
            .Split(' ')
            .Aggregate(string.Empty, (current, word) => current + word[0])
            .ToUpperInvariant();

        var formattedDate = date.ToString("yyyyMMdd");
        return $"{nameInitials}{typeInitials}{formattedDate}";
    }
}