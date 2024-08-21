namespace Services.Features.PatientManagement.Dtos.Account;

public class GetPatientAccountDto
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public string Ppsn { get; set; }
    public string Age { get; set; }
    public string UniqueNumber { get; set; }
    public string AccountType { get; set; }
    public string AccountNotes { get; set; }
    public string InsuranceScheme { get; set; }
    public string PolicyNumber { get; set; }
    public decimal PersonalBalance { get; set; }
    public decimal GroupBalance { get; set; }

}