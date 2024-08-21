using System.ComponentModel.DataAnnotations;
using Shared.Constants.Module;

namespace Services.Features.PatientManagement.Dtos.Alerts;

public class PatientAlertCreateDto
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public AlertSeverity Severity { get; set; }
    public AlertType AlertType { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Please select category")]
    public int AlertCategoryId { get; set; }
    public Guid PatientId { get; set; }
    [Required] public string Details { get; set; }

}