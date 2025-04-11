using Shared.Constants.Module;

namespace Services.Features.PatientManagement.Dtos.Account;

public class PrintStatementDto
{
    public PatientAccountType PatientAccountType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}