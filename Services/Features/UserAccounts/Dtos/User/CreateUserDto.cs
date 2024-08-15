using System.ComponentModel.DataAnnotations;
using Services.Configurations.Attributes;

namespace Services.Features.UserAccounts.Dtos.User;

public class CreateUserDto
{
    [Required(ErrorMessage = "Required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Required")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Required")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Required")]
    [EmailAddress]
    public string Email { get; set; }


    [Required(ErrorMessage = "Required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Required")]
    [MinLength(6)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Required")]
    public string UserType { get; set; }

    [Required(ErrorMessage = "Required")]
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
    public TimeSpan StartHour { get; set; } = new TimeSpan(9, 0, 0);
    public TimeSpan EndHour { get; set; } = new TimeSpan(17, 0, 0);
    public List<int> WorkingDays { get; set; }
    
    [NotEmpty(ErrorMessage = "Required")]
    public Guid RoleId { get; set; }

    
    public int OtherField { get; set; }

}