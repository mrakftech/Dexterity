using System.ComponentModel.DataAnnotations;

namespace Shared.Requests.UserAccounts;

public class ResetPasswordRequest
{
    [Required]
    public string NewPassword { get; set; }
    
    
    
    [Required]
    [Compare("NewPassword")]
    public string ConfirmPassword { get; set; }
}