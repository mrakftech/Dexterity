using Domain.Entities.Settings.Consultation.Immunisation;
using Domain.Entities.UserAccounts;

namespace Domain.Entities.Consultation;

public class AdministerShot
{
    public int Id { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime GivenDate { get; set; }
    public string Side { get; set; }
    
    public User Hcp { get; set; }
    public Guid HcpId { get; set; }

    public ImmunisationSchedule ImmunisationSchedule { get; set; }
    public Guid? ImmunisationScheduleId { get; set; }

    public Shot Shot { get; set; }
    public int? ShotId { get; set; }
    
    public ConsultationDetail ConsultationDetail { get; set; }
    public int? ConsultationDetailId { get; set; }
}