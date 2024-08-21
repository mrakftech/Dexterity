using System.ComponentModel.DataAnnotations;
using Shared.Constants.Module;

namespace Services.Features.Settings.Dtos;

public class AccountTypeDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Required")] public string Name { get; set; }
    public decimal Amount { get; set; } = 0;
    public string Type { get; set; }
    public bool IsActive { get; set; }


    public AccountTypes AccountType { get; set; }
}