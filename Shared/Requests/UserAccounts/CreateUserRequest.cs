using System.ComponentModel.DataAnnotations;


namespace Shared.Requests.UserAccounts;

public class CreateUserRequest
{
    public Guid Id { get; set; } = Guid.Empty;

    [Required(ErrorMessage = "First Name is Required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is Required")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Phone is Required")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Email is Required")]
    [EmailAddress]
    public string Email { get; set; }
    
    public Guid RoleId { get; set; }

    [Required(ErrorMessage = "Username is Required")]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Password is Required")]
    [MinLength(6)]
    public string Password { get; set; }

    [Required(ErrorMessage = "User Type is Required")]
    public string UserType { get; set; }

    [Required(ErrorMessage = "User Role is Required")]
    public string UserRole { get; set; }

    [Required(ErrorMessage = "Mcn is Required")]
    public string Mcn { get; set; }

    public DateTime ResetPasswordAt { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; } = null;

    public string ResetPassword { get; set; }

    public string Ban { get; set; }
    public bool IsUpdatePassword { get; set; }
    public bool IsForceReset { get; set; }
    public bool IsActive { get; set; } = false;
    
}