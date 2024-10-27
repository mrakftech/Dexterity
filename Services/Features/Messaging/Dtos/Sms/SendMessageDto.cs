using System.ComponentModel.DataAnnotations;
using Shared.Attributes;

namespace Services.Features.Messaging.Dtos.Sms;

public class SendMessageDto
{
    [Required(ErrorMessage = "Required")] public string Content { get; set; }
    [Required(ErrorMessage = "Required")] public string Mobile { get; set; }
    [NotEmpty(ErrorMessage = "Required")] public Guid PatientId { get; set; }
    
}