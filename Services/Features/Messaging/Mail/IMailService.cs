using Shared.Requests.Messaging;
using Shared.Requests.Messaging.Sms;

namespace Services.Features.Messaging.Mail
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request, CancellationToken cancellationToken);
    }
}