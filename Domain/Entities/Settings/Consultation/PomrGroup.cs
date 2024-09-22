using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Settings.Consultation;

public class PomrGroup
{
    public int Id { get; set; }
    [Required] public string Name { get; set; }
    public int ClinicId { get; set; }
}