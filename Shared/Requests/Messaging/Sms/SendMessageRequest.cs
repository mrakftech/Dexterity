using System.ComponentModel.DataAnnotations;

namespace Shared.Requests.Messaging.Sms;

public class SendMessageRequest
{
    [Required] public string Content { get; set; }
    [Required] public string Mobile { get; set; }
}