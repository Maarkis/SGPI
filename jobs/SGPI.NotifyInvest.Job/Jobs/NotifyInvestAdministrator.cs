using Quartz;
using SGPI.NotifyInvest.Job.Notifiers.Contract;
using SGPI.NotifyInvest.Job.Queries;

namespace SGPI.NotifyInvest.Job.Jobs;

public class NotifyInvestAdministrator(
    ILogger<NotifyInvestAdministrator> logger,
    IQueriesFinancialProducts queries,
    [FromKeyedServices(Notifier.FluentEmail)]
    INotifier notifier)
    : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        var endOfTomorrow = DateTime
            .Today
            .Date
            .AddDays(2)
            .AddTicks(-1);
        var financialProducts = await queries.GetFinancialProducts(endOfTomorrow);
        if (financialProducts.Count == 0)
        {
            logger.LogInformation("[{time}] - No products found", DateTime.Now);
            return;
        }

        logger.LogInformation("[{time}] - Products found: {count}", DateTime.Now, financialProducts.Count);
        try
        {
            await notifier.SendNotificationForExpiringFinancialProducts(financialProducts);
            logger.LogInformation("[{time}] - Email sent successfully ", DateTime.Now);
        }
        catch (Exception e)
        {
            logger.LogError(e, "[{time}] - Error sending email", DateTime.Now);
            throw;
        }
    }
}