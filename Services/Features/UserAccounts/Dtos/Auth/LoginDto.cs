using System.ComponentModel.DataAnnotations;

namespace Services.Features.UserAccounts.Dtos.Auth;

public class LoginDto
{
    [Required] public string Username { get; set; } = "admin@dexterity";

    [Required] public string Password { get; set; } = "Dexterity123@";
}