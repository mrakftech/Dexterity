using Shared.Constants.Module;

namespace Services.Features.PatientManagement.Dtos.Account;

public class ChargeDto
{
    public DateTime Date { get; set; } = DateTime.Now;
    public decimal Amount { get; set; }
    public PatientAccountType ChargeTo { get; set; } = PatientAccountType.Personal;
    public int ChargeId { get; set; }
    public Guid ChargedById { get; set; }
    public string ChargedName { get; set; }

    public int AccountId { get; set; }
}