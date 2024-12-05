using System.ComponentModel.DataAnnotations;
using Domain.Contracts;
using Domain.Entities.PatientManagement;

namespace Domain.Entities.Consultation.Documents;

public class ScannedDocument : IBaseId
{
    public Guid Id { get; set; }
    public DateTime ScanDate { get; set; } = DateTime.Now;
    [Required(ErrorMessage = "required")] public string Description { get; set; }
    [Required(ErrorMessage = "required")]  public string Type { get; set; }
    [Required(ErrorMessage = "required")]  public string Category { get; set; }
    public string AdditionalNotes { get; set; }
    [Required(ErrorMessage = "required")] public string AttachedFile { get; set; }

    public Patient Patient { get; set; }
    public Guid PatientId { get; set; }
}