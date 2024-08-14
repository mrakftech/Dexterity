using System.ComponentModel.DataAnnotations;

namespace Services.Features.UserAccounts.Dtos.Auth;

public class LoginDto
{
    [Required(ErrorMessage = "Required")] public string Username { get; set; } = "admin@dexterity";

    [Required(ErrorMessage = "Required")] public string Password { get; set; } = "Dexterity123@";
}