using System.ComponentModel.DataAnnotations;

namespace Services.Features.Messaging.Dtos.Sms;

public class InvitePatientDto
{
    [Required(ErrorMessage = "Required")] public string To { get; set; } 
}