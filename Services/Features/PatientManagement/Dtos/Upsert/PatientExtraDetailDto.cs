using Domain.Entities.PatientManagement.Extra;
using Syncfusion.Blazor.TreeGrid.Internal;

namespace Services.Features.PatientManagement.Dtos.Upsert;

public class PatientExtraDetailDto
{
    public string Ethnicity { get; set; }
    public string Religion { get; set; }
    public string PreferredLanguage { get; set; }
    public string TransportNeeds { get; set; }
    public string AdvocacyNeeds { get; set; }
    public string InterpreterRequired { get; set; }


    public string Status { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; } = DateTime.Now;
    public Guid PatientId { get; set; }
}