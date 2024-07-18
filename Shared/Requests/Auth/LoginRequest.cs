using System.ComponentModel.DataAnnotations;

namespace Shared.Requests.Auth;

public class LoginRequest
{
    [Required] public string Username { get; set; } = "admin@dexterity";

    [Required] public string Password { get; set; } = "Dexterity123@";
}