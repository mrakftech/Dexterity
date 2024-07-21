using System.ComponentModel.DataAnnotations;

namespace Services.Features.UserAccounts.Dtos.User;

public class ResetPasswordDto
{
    [Required]
    public string NewPassword { get; set; }
    
    
    
    [Required]
    [Compare("NewPassword")]
    public string ConfirmPassword { get; set; }
}