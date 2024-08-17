namespace Services.Features.PatientManagement.Dtos.Grouping;

public class GroupDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string GroupHead { get; set; }

    public decimal Balance { get; set; }
    public int RegisteredPatientsCount { get; set; }
}