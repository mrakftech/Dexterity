namespace Services.Features.UserAccounts.Dtos.User;

public class HealthcareDto
{
    public Guid Id { get; set; }
    public string Name{ get; set; }
    public string Address1 { get; set; }
    public string GsmNumber{ get; set; }
    public string UserType { get; set; }
    public string StartHour { get; set; }
    public string EndHour { get; set; }
    public int[] WorkingDays { get; set; }

}