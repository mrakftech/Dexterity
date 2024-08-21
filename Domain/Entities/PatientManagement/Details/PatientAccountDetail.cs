using Domain.Contracts;

namespace Domain.Entities.PatientManagement.Details;

public class PatientAccountDetail 
{
    public string AccountType { get; set; }
    public string AccountNotes { get; set; }
    public string InsuranceScheme { get; set; }
    public string PolicyNumber { get; set; }
    public decimal PersonalBalance { get; set; }

    public string BillingName { get; set; }
    public string BillingDetail { get; set; }
}