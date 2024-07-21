using Services.Features.Messaging.Dtos.Sms;

namespace Services.Features.Messaging.Mail
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request, CancellationToken cancellationToken);
    }
}