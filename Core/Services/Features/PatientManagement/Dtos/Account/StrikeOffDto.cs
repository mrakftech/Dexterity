using Shared.Attributes;
using Shared.Constants.Module;

namespace Services.Features.PatientManagement.Dtos.Account;

public class StrikeOffDto
{
    public DateTime Date { get; set; } = DateTime.Now;
    public decimal Amount { get; set; }
    public PatientAccountType PaymentTo { get; set; } = PatientAccountType.Personal;
    [NotEmpty(ErrorMessage = "Required")] public Guid HcpId { get; set; }
    public int AccountId { get; set; }
    public decimal TotalAmount { get; set; }
    public string AccountType { get; set; }
    public string StrikeOffName { get; set; }
    public int AccountTypeId { get; set; }
    public string Description { get; set; }

    public List<GetTransactionDto> SelectedTransaction { get; set; } = new();
}