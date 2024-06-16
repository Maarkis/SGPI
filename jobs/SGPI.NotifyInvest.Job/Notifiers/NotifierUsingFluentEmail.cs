using FluentEmail.Core;
using Microsoft.Extensions.Options;
using SGPI.NotifyInvest.Job.Models;
using SGPI.NotifyInvest.Job.Notifiers.Contract;

namespace SGPI.NotifyInvest.Job.Notifiers;

public class NotifierUsingFluent(IFluentEmail fluentEmail, IOptions<Recipient> recipients) : INotifier
{
    public async Task SendNotificationForExpiringFinancialProducts(List<FinancialProduct> financialProducts,
        CancellationToken cancellationToken = default)
    {
        var to = recipients.Value;
        ArgumentNullException.ThrowIfNull(recipients);

        var folder = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "NotificationTemplate.cshtml");
        await fluentEmail
            .To(to.Email, to.Name)
            .Subject("Produtos expirando")
            .UsingTemplateFromFile(folder, new { Products = financialProducts })
            .SendAsync(cancellationToken)
            .ConfigureAwait(false);
    }
}