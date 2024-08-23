using System.ComponentModel.DataAnnotations;
using Services.Configurations.Attributes;
using Shared.Constants.Module;

namespace Services.Features.PatientManagement.Dtos.Account;

public class ChargeDto
{
    public DateTime Date { get; set; } = DateTime.Now;

    [Range(0, double.MaxValue)]
    public decimal Amount { get; set; }
    public PatientAccountType ChargeTo { get; set; } = PatientAccountType.Personal;

    [NotEmpty(ErrorMessage = "Required")]
    public Guid ChargedById { get; set; }
    public string AccountType { get; set; }
    public int AccountTypeId { get; set; }
    public int AccountId { get; set; }
    public string Description { get; set; }
}