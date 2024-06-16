using Microsoft.Extensions.Options;
using SGPI.NotifyInvest.Job.Clients;
using SGPI.NotifyInvest.Job.Models;
using SGPI.NotifyInvest.Job.Notifiers.Contract;

namespace SGPI.NotifyInvest.Job.Notifiers;

[Obsolete($"Use {nameof(NotifierUsingSenderClient)} instead")]
public class NotifierUsingSenderClient(
    ISenderClient senderClient,
    IOptions<MainSendClientConfig> mainSendClientConfig,
    IOptions<Recipient> recipients) : INotifier
{
    [Obsolete("Use {nameof(EmailNotifierUsingSenderClient)} instead")]
    public async Task SendNotificationForExpiringFinancialProducts(List<FinancialProduct> financialProducts,
        CancellationToken cancellationToken = default)
    {
        var productsHtml = financialProducts
            .Aggregate("", (current, financialProduct) => current + $"""
                                                                         <tr>
                                                                             <td>{financialProduct.ProductCode}</td>
                                                                             <td>{financialProduct.Name}</td>
                                                                             <td>{financialProduct.MaturityDate}</td>
                                                                         </tr>
                                                                         
                                                                     """);

        const string html = """
                            <!DOCTYPE html>
                            <html lang="pt-br">
                            <head>
                              <style>
                                table {
                                  font-family: arial, sans-serif;
                                  border-collapse: collapse;
                                  width: 100%;
                                }
                            
                                td, th {
                                  border: 1px solid #d3d3d3;
                                  text-align: left;
                                  padding: 8px;
                                }
                            
                                tr:nth-child(even) {
                                  background-color: #dddddd;
                                }
                              </style>
                              <title> Notification </title>
                            </head>
                            <body>

                            <h2>Produtos expirando</h2>
                            <table>
                              <tr>
                                <th>Código do produto</th>
                                <th>Nome</th>
                                <th>Data</th>
                              </tr>
                            
                              {{Model.Products}}
                            </table>
                            </body>
                            </html>

                            """;

        var emailConfig = mainSendClientConfig.Value;
        ArgumentNullException.ThrowIfNull(emailConfig);

        var to = recipients.Value;
        ArgumentNullException.ThrowIfNull(recipients);

        var email = new EmailBuilder()
            .From(emailConfig.Name, emailConfig.Email)
            .To(to.Name, to.Email)
            .Subject("Produtos expirando")
            .Html(html.Replace("{{Model.Products}}", productsHtml))
            .Build();

        await senderClient.SendEmail(email, cancellationToken);
    }
}