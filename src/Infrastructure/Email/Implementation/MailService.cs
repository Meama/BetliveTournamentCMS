using MimeKit;
using System.Threading;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Infrastructure.Email.Abstraction;
using Infrastructure.Email.Configuration;

namespace Infrastructure.Email.Implementation;

public class MailService : IMailService
{
    private readonly IOptions<EmailOptions> _emailOptions;

    public MailService(IOptions<EmailOptions> emailOptions)
    {
        _emailOptions = emailOptions;
    }

    public async Task SendEmailAsync(string body, string toEmailAddress, string subject = null, CancellationToken cancellationToken = default)
    {
        var message = new MimeMessage();
        message.From.Add(MailboxAddress.Parse(_emailOptions.Value.EmailAddress));
        message.To.Add(MailboxAddress.Parse(toEmailAddress));
        if (subject != null)
        {
            message.Subject = subject;
        }

        message.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

        using SmtpClient client = new();
        client.Connect("smtp.gmail.com", 587, false, cancellationToken);
        client.Authenticate(_emailOptions.Value.EmailAddress, _emailOptions.Value.EmailPassword, cancellationToken);
        var result = await client.SendAsync(message, cancellationToken);
        client.Disconnect(true, cancellationToken);
    }
}