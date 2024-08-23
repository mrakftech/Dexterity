namespace Services.Features.PatientManagement.Dtos.Account;

public class AccountStatementDto
{
    public decimal Balance { get; set; }
    public decimal BalancebBroughtForward { get; set; }
    public List<GetTransactionDto> PatientTransactions { get; set; } = new();
}