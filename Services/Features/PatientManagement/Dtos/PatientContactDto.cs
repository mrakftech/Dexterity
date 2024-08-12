using System.ComponentModel.DataAnnotations;

namespace Services.Features.PatientManagement.Dtos;

public class PatientContactDto
{
    public int Id { get; set; }
    [Required] public string Surname { get; set; }
    [Required] public string FirstName { get; set; }
    public DateTime DateOfBirth { get; set; } = DateTime.Now;
    [Required] public string Address { get; set; }
    [Required] public string Gender { get; set; }
    [Required] public string Phone { get; set; }

    public Guid PatientId { get; set; }
}