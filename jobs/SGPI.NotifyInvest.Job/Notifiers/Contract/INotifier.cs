using SGPI.NotifyInvest.Job.Models;

namespace SGPI.NotifyInvest.Job.Notifiers.Contract;

public interface INotifier
{
    public Task SendNotificationForExpiringFinancialProducts(List<FinancialProduct> financialProducts,
        CancellationToken cancellationToken = default);
}