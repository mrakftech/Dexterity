using System.ComponentModel.DataAnnotations;

namespace Services.Features.Messaging.Dtos.Sms;

public class SendMessageDto
{
    [Required] public string Content { get; set; }
    [Required] public string Mobile { get; set; }
}