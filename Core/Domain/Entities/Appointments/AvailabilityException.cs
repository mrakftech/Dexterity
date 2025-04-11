using Domain.Contracts;

namespace Domain.Entities.Appointments;

public class AvailabilityException : IBaseId
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; } =DateTime.UtcNow;
    public string Type { get; set; }
    public string Subject { get; set; }
    public DateTime StartTime { get; set; } = new(DateTime.Now.Year, DateTime.Now.Month,  1, 9, 00, 0);
    public DateTime EndTime { get; set; } = new(DateTime.Now.Year, DateTime.Now.Month,  1, 9, 00, 0);
    public string Reason { get; set; }
    
    public bool IsBlock { get; set; }
    public Guid HcpId { get; set; }
}