using FluentEmail.Core;
using Microsoft.Extensions.Options;
using SGPI.NotifyInvest.Job.Models;
using SGPI.NotifyInvest.Job.Notifiers.Contract;

namespace SGPI.NotifyInvest.Job.Notifiers;

public class NotifierUsingFluent(IFluentEmail fluentEmail, IOptions<Recipient> recipients) : INotifier
{
    private readonly string _templatePath = Path
        .Combine(Directory.GetCurrentDirectory(), "Templates", "NotificationTemplate.cshtml");

    public async Task SendNotificationForExpiringFinancialProducts(List<FinancialProduct> financialProducts,
        CancellationToken cancellationToken = default)
    {
        var to = recipients.Value;
        ArgumentNullException.ThrowIfNull(recipients);
        
        await fluentEmail
            .To(to.Email, to.Name)
            .Subject("Produtos expirando")
            .UsingTemplateFromFile(_templatePath, new { Products = financialProducts })
            .SendAsync(cancellationToken)
            .ConfigureAwait(false);
    }
}