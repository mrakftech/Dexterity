using Services.Features.PatientManagement.Dtos.Details;

namespace Services.Features.Messaging.Dtos.Sms;

public class BulkSmsDto
{
    public List<PatientListDto> Patients { get; set; }
    public string Content { get; set; }
}