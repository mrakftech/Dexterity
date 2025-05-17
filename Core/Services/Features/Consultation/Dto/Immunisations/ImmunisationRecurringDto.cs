using System.ComponentModel.DataAnnotations;
using Services.State;
using Shared.Attributes;

namespace Services.Features.Consultation.Dto.Immunisations;

public class ImmunisationRecurringDto
{
    [NotEmpty(ErrorMessage = "Please select schedule")]
    public Guid ImmunisationProgramId { get; set; }

    public Guid PatientId { get; set; } = ApplicationState.GetSelectPatientId();
    public DateTime StartDate { get; set; } = DateTime.Now;
    
    [Range(1, 15)]
    public int SpecifiedCount { get; set; } 
    
    [Range(3, int.MaxValue)]
    public int RecurrenceInterval { get; set; }
}