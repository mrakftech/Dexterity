using Domain.Entities.Settings.Consultation;
using System.ComponentModel.DataAnnotations;

namespace Services.Features.Settings.Dtos;

public class NoteTemplateDto
{
    public int Id { get; set; }
    [Required] public string Note { get; set; }
    public bool IsActive { get; set; }

    public HealthCode HealthCode { get; set; }

    [Range(1, int.MaxValue,ErrorMessage = "Please Select code")]
    public int HealthCodeId { get; set; }
}