using Shared.Constants.Module;

namespace Domain.Entities.PatientManagement.Billing;

public class PatientTransaction 
{
    public int Id { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsDeleted { get; set; }
    public string Description { get; set; }
    public string ActionType { get; set; } = "-";
    public bool IsPrinted { get; set; }
    public TransactionType TransactionType { get; set; }
    public PatientAccountType PatientAccountType { get; set; }
    public decimal Debit { get; set; }
    public decimal Credit { get; set; }
    public decimal Balance { get; set; }

    public PatientAccount PatientAccount { get; set; }
    public int PatientAccountId { get; set; }
}