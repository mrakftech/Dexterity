using System.ComponentModel.DataAnnotations;
using Domain.Contracts;
using Domain.Entities.PatientManagement;
using Domain.Entities.Settings.Consultation.Immunisation;

namespace Domain.Entities.Consultation;

public class ImmunisationSchedule:IBaseId
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime ScheduleDate { get; set; } = DateTime.Now;

    public ImmunisationSetup ImmunisationSetup { get; set; }
    
    [Range(1, int.MaxValue,ErrorMessage = "Please select schedule")]
    public int ImmunisationSetupId { get; set; }
    public Patient Patient { get; set; }
    public Guid PatientId { get; set; }

}