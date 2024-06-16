using System.Net.Http.Json;
using SGPI.NotifyInvest.Job.Models;

namespace SGPI.NotifyInvest.Job.Clients;

public interface ISenderClient
{
    Task SendEmail(Email email, CancellationToken cancellationToken = default);
}

public class MailSenderClient(HttpClient client) : ISenderClient
{
    public async Task SendEmail(Email email, CancellationToken cancellationToken = default)
    {
        var response = await client.PostAsJsonAsync("/v1/email", email, cancellationToken);
        response.EnsureSuccessStatusCode();
    }
}