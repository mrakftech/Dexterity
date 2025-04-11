using Services.State;
using Shared.Attributes;

namespace Services.Features.Consultation.Dto.Letter;

public class LetterDto
{
    public DateTime LetterDt { get; set; } = DateTime.Now;
    public string ReferTo { get; set; } = "The Patient";
    public string Reference { get; set; } = ApplicationState.SelectedPatient.Name;
    public string Description { get; set; }

   [NotEmpty(ErrorMessage = "Required")] public Guid LetterTypeId { get; set; }
    [NotEmpty(ErrorMessage = "Required")]  public Guid LetterTemplateId { get; set; }
    [NotEmpty(ErrorMessage = "Required")] public Guid HcpId { get; set; }
}