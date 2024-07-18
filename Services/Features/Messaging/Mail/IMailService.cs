using Shared.Requests.Messaging;

namespace Services.Features.Messaging.Mail
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request, CancellationToken cancellationToken);
    }
}