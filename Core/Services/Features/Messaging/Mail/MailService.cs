using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using Services.Configurations;
using Services.Features.Messaging.Dtos.Sms;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Services.Features.Messaging.Mail;

public class MailService(IOptions<MailConfiguration> config, ILogger<MailService> logger)
    : IMailService
{
    private readonly MailConfiguration _config = config.Value;

    public async Task SendAsync(MailRequest request,CancellationToken cancellationToken)
    {
        try
        {
            var email = new MimeMessage
            {
                Sender = new MailboxAddress(_config.DisplayName,  _config.From),
                Subject = request.Subject,
            };
            var builder = new BodyBuilder();

            email.To.Add(MailboxAddress.Parse(request.To));
            await GetAttachments(request, cancellationToken, builder);
            builder.HtmlBody = request.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_config.Host, _config.Port, SecureSocketOptions.StartTls, cancellationToken);
            await smtp.AuthenticateAsync(_config.UserName, _config.Password, cancellationToken);
            await smtp.SendAsync(email, cancellationToken);
            await smtp.DisconnectAsync(true, cancellationToken);
            logger.LogInformation("Mail has been sent");
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, request.To);
            logger.LogError(ex.Message, ex);
        }
    }
    
    private static async Task GetAttachments(MailRequest request, CancellationToken cancellationToken, BodyBuilder builder)
    {
        if (request.Attachments.Count > 0)
        {
            foreach (var item in request.Attachments)
            {
                if (!File.Exists(item)) continue;
                var filename =  Path.GetFileName(item);
                var file = new FileStream(item, FileMode.Open, FileAccess.Read);
                using var ms = new MemoryStream();
                await file.CopyToAsync(ms, cancellationToken);
                var fileBtyes = ms.ToArray();
                builder.Attachments.Add(filename, fileBtyes, ContentType.Parse("application/octet-stream"));
            }
        }
    }

    
}