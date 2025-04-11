namespace Domain.Entities.PatientManagement.Extra;

public class RelatedHcp
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Telephone { get; set; }
    public string Fax { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
}