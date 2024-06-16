namespace SGPI.Application.Infrastructure.Database.Contracts;

// TODO: Unit of work ...
public interface ISaveRepository
{
    public Task SaveAsync(CancellationToken cancellationToken = default);
}