using Shared.Constants.Module;

namespace Services.Features.PatientManagement.Dtos.Account;

public class PaymentDto
{
    public DateTime Date { get; set; } = DateTime.Now;
    public decimal Amount { get; set; }
    public PatientAccountType ChargeTo { get; set; } = PatientAccountType.Personal;
    public PaymentType PaymentType { get; set; } = PaymentType.Cash;
    public Guid HcpId { get; set; }
    public int AccountId { get; set; }

    public List<GetTransactionDto> SelectedTransaction { get; set; }
}