namespace Domain.Entities.PatientManagement.Options;

public class SmsHistory
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Content { get; set; }
    public string Mobile { get; set; }
    public Patient Patient { get; set; }
    public Guid PatientId { get; set; }
}