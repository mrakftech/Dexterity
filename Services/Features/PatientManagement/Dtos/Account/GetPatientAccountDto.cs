using Services.Features.PatientManagement.Dtos.Details;
using Shared.Constants.Module;

namespace Services.Features.PatientManagement.Dtos.Account;

public class GetPatientAccountDto
{
    public int Id { get; set; }
    public PatientAccountType Type { get; set; } = PatientAccountType.Personal;
    public AccountView AccountView { get; set; }
    public string Age { get; set; }
    public decimal Balance { get; set; }
    public string InsuranceScheme { get; set; }
    public decimal GroupBalance { get; set; }
    public string BillingName { get; set; } = "";
    public string BillingDetail { get; set; } = "";
    public PatientDto Patient { get; set; } = new();
    public List<GetTransactionDto> Transactions { get; set; } = new();
}