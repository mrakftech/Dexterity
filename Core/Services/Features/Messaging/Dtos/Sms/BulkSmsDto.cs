using System.ComponentModel.DataAnnotations;
using Services.Features.PatientManagement.Dtos.Details;

namespace Services.Features.Messaging.Dtos.Sms;

public class BulkSmsDto
{
    public List<PatientListDto> Patients { get; set; }
    [Required(ErrorMessage = "Required")] public string Content { get; set; }
}