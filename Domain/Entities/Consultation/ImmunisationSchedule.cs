using System.ComponentModel.DataAnnotations;
using Domain.Contracts;
using Domain.Entities.PatientManagement;
using Domain.Entities.Settings.Consultation.Immunisation;
using Shared.Attributes;

namespace Domain.Entities.Consultation;

public class ImmunisationSchedule : IBaseId
{
    [Key] public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime ScheduleDate { get; set; } = DateTime.Now;

    public ImmunisationProgram ImmunisationProgram { get; set; }

    [NotEmpty(ErrorMessage = "Please select schedule")]
    public Guid ImmunisationProgramId { get; set; }

    public Patient Patient { get; set; }
    public Guid PatientId { get; set; }
}