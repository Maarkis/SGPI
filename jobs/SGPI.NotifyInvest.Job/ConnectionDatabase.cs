using System.Data;
using Npgsql;

namespace SGPI.NotifyInvest.Job;

public interface IDatabase : IAsyncDisposable
{
    Task<IDbConnection> ConnectAsync(CancellationToken cancellationToken = default);
    Task CloseAsync(CancellationToken cancellationToken = default);
}

public sealed class Database(string connectionString, ILogger<Database> logger) : IDatabase
{
    private NpgsqlConnection? _connection;

    public async Task<IDbConnection> ConnectAsync(CancellationToken cancellationToken = default)
    {
        if (_connection?.State is ConnectionState.Open)
            return _connection;

        _connection = new NpgsqlConnection(connectionString);
        try
        {
            await _connection.OpenAsync(cancellationToken);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error connecting to database");
            throw;
        }

        return _connection;
    }

    public async Task CloseAsync(CancellationToken cancellationToken = default)
    {
        if (_connection is { State: not ConnectionState.Closed })
            try
            {
                await _connection.CloseAsync();
                logger.LogInformation("Database connection closed successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to close database connection.");
                throw;
            }
            finally
            {
                await _connection.DisposeAsync();
                _connection = null;
            }
    }

    public async ValueTask DisposeAsync()
    {
        await CloseAsync();
    }
}