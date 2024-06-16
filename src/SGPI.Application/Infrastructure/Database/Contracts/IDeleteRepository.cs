namespace SGPI.Application.Infrastructure.Database.Contracts;

public interface IDeleteRepository
{
    public Task RemoveAsync(Guid id, CancellationToken cancellationToken = default);
}