using System.ComponentModel.DataAnnotations;

namespace Services.Features.Messaging.Dtos.Sms;

public class SendMessageDto
{
    [Required(ErrorMessage = "Required")] public string Content { get; set; }
    [Required(ErrorMessage = "Required")] public string Mobile { get; set; }
}