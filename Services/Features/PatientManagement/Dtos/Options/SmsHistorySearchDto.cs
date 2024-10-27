using Shared.Attributes;

namespace Services.Features.PatientManagement.Dtos.Options;

public class SmsHistorySearchDto
{
    [NotEmpty]
    public Guid PatientId { get; set; }
    public DateTime From { get; set; } = DateTime.Now;
    public DateTime To { get; set; } = DateTime.Now.AddDays(-30);
    public string Id { get; set; }
}
