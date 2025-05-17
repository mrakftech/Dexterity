using System.ComponentModel.DataAnnotations;
using Services.State;

namespace Services.Features.PatientManagement.Dtos.Allergies;

public class UpsertAllergyDto
{
    public DateTime Date { get; set; } = DateTime.Now;
    [Required] public string AllergyName { get; set; }
    public string PatientName { get; set; } = ApplicationState.Patient.Name;
    
    public Guid PatientId { get; set; }= ApplicationState.GetSelectPatientId();

    [Required] public string Notes { get; set; }
}