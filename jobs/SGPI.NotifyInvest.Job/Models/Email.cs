namespace SGPI.NotifyInvest.Job.Models;

public record Sender(string Name, string Email);

public class Recipient()
{
    public Recipient(string name, string email) : this()
    {
        Name = name;
        Email = email;
    }

    public string Name { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
}

public class Email
{
    public required Sender From { get; init; }
    public required List<Recipient> To { get; init; }
    public required string Subject { get; init; }
    public required string Html { get; init; }
    public required Dictionary<string, string> Personalization { get; init; }
}

public class EmailBuilder
{
    private readonly Dictionary<string, string> _personalization = new();
    private readonly List<Recipient> _recipients = Enumerable.Empty<Recipient>().ToList();
    private string _html = string.Empty;
    private Sender? _sender;
    private string _subject = string.Empty;

    public EmailBuilder From(string name, string email)
    {
        _sender = new Sender(name, email);
        return this;
    }

    public EmailBuilder To(string name, string email)
    {
        _recipients.Add(new Recipient(name, email));
        return this;
    }

    public EmailBuilder To(Recipient recipient)
    {
        _recipients.Add(recipient);
        return this;
    }

    public EmailBuilder To(List<Recipient> to)
    {
        _recipients.AddRange(to);
        return this;
    }

    public EmailBuilder Subject(string subject)
    {
        _subject = subject;
        return this;
    }

    public EmailBuilder Html(string html)
    {
        _html = html;
        return this;
    }

    public EmailBuilder Personalization(string key, string value)
    {
        _personalization.Add(key, value);
        return this;
    }

    public Email Build()
    {
        ArgumentException.ThrowIfNullOrEmpty(_subject, nameof(_subject));
        ArgumentException.ThrowIfNullOrEmpty(_html, nameof(_html));
        ArgumentNullException.ThrowIfNull(_sender, nameof(_sender));
        ArgumentNullException.ThrowIfNull(_recipients, nameof(_recipients));

        return new Email
        {
            From = _sender,
            To = _recipients,
            Subject = _subject,
            Html = _html,
            Personalization = _personalization
        };
    }
}