using System.ComponentModel.DataAnnotations;
using Shared.Constants.Module;

namespace Services.Features.PatientManagement.Dtos.Alerts;

public class PatientAlertDto
{
    public Guid Id { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public bool IsDeleted { get; set; }

    public string Category { get; set; }
    public string Type { get; set; }
    public string Severity { get; set; }
    public string Status { get; set; }
    public string Details { get; set; }
    public bool IsResolved { get; set; }
    public Guid PatientId { get; set; }
    public int AlertCategoryId { get; set; }
}