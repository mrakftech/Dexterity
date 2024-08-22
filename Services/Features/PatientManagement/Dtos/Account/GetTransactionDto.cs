using Shared.Constants.Module;

namespace Services.Features.PatientManagement.Dtos.Account;

public class GetTransactionDto
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsDeleted { get; set; }
    public string Description { get; set; }
    public bool IsPrinted { get; set; }
    public TransactionType TransactionType { get; set; }
    public decimal Amount { get; set; }
    public decimal Balance { get; set; }
    public Guid PatientId { get; set; }
}