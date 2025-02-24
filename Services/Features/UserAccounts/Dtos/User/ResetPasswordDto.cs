using System.ComponentModel.DataAnnotations;
using Shared.Attributes;

namespace Services.Features.UserAccounts.Dtos.User;

public class ResetPasswordDto
{
    [Required(ErrorMessage = "Required field")]
    [PasswordRequirements(MinLength = 12)] // Use the custom attribute
    public string NewPassword { get; set; }
    
    [Required(ErrorMessage = "Required field")]
    [Compare("NewPassword", ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; }
}