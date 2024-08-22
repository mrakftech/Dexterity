using Shared.Constants.Module;

namespace Domain.Entities.PatientManagement.Billing;

public class PatientAccount
{
    public int Id { get; set; }
    public PatientAccountType Type { get; set; }
    public decimal Balance { get; set; }

    public Patient Patient { get; set; }
    public Guid PatientId { get; set; }

    public ICollection<PatientTransaction> PatientTransactions { get; set; }
}