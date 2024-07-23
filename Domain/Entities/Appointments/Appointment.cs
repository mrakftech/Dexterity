using Domain.Contracts;
using Domain.Entities.PatientManagement;

namespace Domain.Entities.Appointments;

public class Appointment : IBaseId, IBaseActionBy, IBaseActionOn
{
    public Guid Id { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public bool IsDeleted { get; set; }
    
    public int Duration { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Color { get; set; }
    public string Title { get; set; }
    public Patient Patient { get; set; }
    public Guid PatientId { get; set; }
}