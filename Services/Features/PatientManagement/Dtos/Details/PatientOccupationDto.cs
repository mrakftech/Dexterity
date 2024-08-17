namespace Services.Features.PatientManagement.Dtos.Details;

public class PatientOccupationDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; } = DateTime.Now;
    public Guid PatientId { get; set; }
}