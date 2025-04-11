using System.ComponentModel.DataAnnotations;
using Services.Features.PatientManagement.Dtos.Details;
using Shared.Constants.Module;

namespace Services.Features.PatientManagement.Dtos.Options;

public class CreatePatientGroupAlertDto
{
    public List<PatientListDto> SelectedPatients { get; set; } = new();
    
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public AlertSeverity Severity { get; set; }
    public AlertType AlertType { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Please select category")]
    public int AlertCategoryId { get; set; }
    [Required] public string Details { get; set; }
}