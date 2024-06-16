using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using Quartz;
using SGPI.NotifyInvest.Job;
using SGPI.NotifyInvest.Job.Clients;
using SGPI.NotifyInvest.Job.Jobs;
using SGPI.NotifyInvest.Job.Models;
using SGPI.NotifyInvest.Job.Notifiers;
using SGPI.NotifyInvest.Job.Notifiers.Contract;
using SGPI.NotifyInvest.Job.Queries;

var builder = Host
    .CreateDefaultBuilder(args)
    .ConfigureServices((host, services) =>
    {
        var configuration = host.Configuration;

        services.Configure<Recipient>(configuration.GetRequiredSection("Recipient"));
        services.Configure<MainSendClientConfig>(configuration.GetRequiredSection(MainSendClientConfig.Key));

        var smtpConfig = configuration.GetRequiredSection(MailSenderSmtpConfig.Key).Get<MailSenderSmtpConfig>();
        ArgumentNullException.ThrowIfNull(smtpConfig);

        services
            .AddFluentEmail(smtpConfig.Email, smtpConfig.Name)
            .AddRazorRenderer()
            .AddSmtpSender(
                smtpConfig.Host,
                smtpConfig.Port,
                smtpConfig.Username,
                smtpConfig.Password);


        services.AddHttpClient<ISenderClient, MailSenderClient>((sp, client) =>
        {
            var mainSendClientConfig = sp.GetRequiredService<IOptions<MainSendClientConfig>>();

            var senderUrl = mainSendClientConfig.Value.Url;
            var token = mainSendClientConfig.Value.Token;
            ArgumentException.ThrowIfNullOrEmpty(senderUrl, nameof(senderUrl));
            ArgumentException.ThrowIfNullOrEmpty(token, nameof(token));

            client.BaseAddress = new Uri(senderUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        });

        var connectionDatabase = configuration.GetConnectionString("AppDb");
        ArgumentException.ThrowIfNullOrEmpty(connectionDatabase, nameof(connectionDatabase));
        services
            .AddScoped<IQueriesFinancialProducts, QueriesFinancialProducts>()
# pragma warning disable CS0618
            .AddKeyedScoped<INotifier, NotifierUsingSenderClient>(Notifier.SenderClient)
            .AddKeyedScoped<INotifier, NotifierUsingFluent>(Notifier.FluentEmail)
            .AddSingleton<IDatabase, Database>(x =>
                new Database(
                    connectionDatabase,
                    x.GetRequiredService<ILogger<Database>>()))
            .AddQuartz()
            .AddQuartzHostedService(opt => { opt.WaitForJobsToComplete = true; });
    });
var host = builder.Build();
var scheduleFactory = host.Services.GetRequiredService<ISchedulerFactory>();


var scheduler = await scheduleFactory.GetScheduler();
var notifyInvestAdministratorJob = JobBuilder
    .Create<NotifyInvestAdministrator>()
    .WithIdentity("JobNotifyInvestAdministrator", "Notify Invest")
    .WithDescription("Notify invest administrator job")
    .Build();

// var trigger = TriggerBuilder
//     .Create()
//     .WithIdentity("TriggerNotifyInvestAdministrator", "Notify Invest")
//     .WithDescription("Notify invest administrator trigger")
//     .WithCronSchedule("0 0/1 * * * ?")
//     .Build();

var trigger = TriggerBuilder.Create()
    .WithIdentity("ScheduleIsFavoriteJob", "Tag")
    .StartAt(DateTimeOffset.Now.AddSeconds(1))
    .WithSimpleSchedule(x => x
        .WithIntervalInMinutes(15)
        .RepeatForever())
    .Build();


await scheduler.ScheduleJob(notifyInvestAdministratorJob, trigger);
await host.RunAsync();