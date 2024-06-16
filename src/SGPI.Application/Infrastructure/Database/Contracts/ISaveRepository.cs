namespace SGPI.Application.Infrastructure.Database.Contracts;

public interface ISaveRepository
{
    public Task SaveAsync(CancellationToken cancellationToken = default);
}