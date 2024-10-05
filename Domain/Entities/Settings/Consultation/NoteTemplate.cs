using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Settings.Consultation;

public class NoteTemplate
{
    public int Id { get; set; }
    [Required] public string Note { get; set; }
    public bool IsActive { get; set; }
    public HealthCode HealthCode { get; set; }
    
    [Range(1, int.MaxValue)]
    public int? HealthCodeId { get; set; }
}