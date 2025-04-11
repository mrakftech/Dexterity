using Shared.Constants.Module;

namespace Domain.Entities.Settings.Account;

public class AccountType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public TransactionActionType Type { get; set; }
    public bool IsActive { get; set; }
}