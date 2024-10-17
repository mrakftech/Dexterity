using Domain.Entities.Settings.Clinic;

namespace Domain.Entities.UserAccounts;

public class UserClinic
{
    public int Id { get; set; }

    public Clinic Clinic { get; set; }
    public int ClinicId { get; set; }
    
    public User User { get; set; }
    public Guid UserId { get; set; }
}