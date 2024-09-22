using Shared.Constants.Module;

namespace Domain.Entities.PatientManagement.Billing;

public class PatientAccount
{
    public int Id { get; set; }
    public PatientAccountType Type { get; set; } = PatientAccountType.Personal;
    public decimal Balance { get; set; } = 500;

    public Patient Patient { get; set; }
    public Guid PatientId { get; set; }

    public ICollection<PatientTransaction> PatientTransactions { get; set; }
}