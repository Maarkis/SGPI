using System.ComponentModel.DataAnnotations;

namespace SGPI.NotifyInvest.Job;

public class MailSenderSmtpConfig
{
    public const string Key = "MailSenderSMTP";

    [Required] public required string Host { get; set; }

    [Required] public required int Port { get; set; }

    [Required] public required string Username { get; set; }

    [Required] public required string Password { get; set; }

    [Required] public required string Name { get; set; }

    [Required] public required string Email { get; set; }
}

public class MainSendClientConfig
{
    public const string Key = "MailSendClient";

    [Required] public required string Url { get; set; }

    [Required] public required string Token { get; set; }

    [Required] public required string Name { get; set; }

    [Required] public required string Email { get; set; }
}