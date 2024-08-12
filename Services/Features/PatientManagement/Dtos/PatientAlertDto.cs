using Shared.Constants.Module;
using System.ComponentModel.DataAnnotations;

namespace Services.Features.PatientManagement.Dtos;

public class PatientAlertDto
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public AlertSeverity Severity { get; set; }
    [Required] public string Details { get; set; }
    public string CategoryName { get; set; }
    public AlertTypes AlertType { get; set; }
    public bool IsResolved { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Please select category")]
    public int AlertCategoryId { get; set; }

    public Guid PatientId { get; set; }

}