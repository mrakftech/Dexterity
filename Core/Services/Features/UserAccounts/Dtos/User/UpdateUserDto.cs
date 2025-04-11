using System.ComponentModel.DataAnnotations;
using Shared.Attributes;

namespace Services.Features.UserAccounts.Dtos.User;

public class UpdateUserDto
{
    [Required(ErrorMessage = "*")] public string FirstName { get; set; }

    [Required(ErrorMessage = "*")] public string LastName { get; set; }

    [Required(ErrorMessage = "*")]
    [EmailAddress]
    public string Email { get; set; }


    [Required(ErrorMessage = "*")]
    //[StringLength(50, MinimumLength = 1, ErrorMessage = "Username must be between 1 and 50 characters.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "*")] public string Mcn { get; set; }

    public DateTime ResetPasswordAt { get; set; }
    public string ResetPassword { get; set; }


    public string Ban { get; set; }
    public bool IsUpdatePassword { get; set; }
    public bool IsForceReset { get; set; }
    public bool IsActive { get; set; } = false;
    public bool IsLockOut { get; set; } = false;
    
    public string MobileNumber { get; set; }
    public string FaxNo { get; set; }
    public string TelePhone { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string Address3 { get; set; }
    public string Address4 { get; set; }
    public string Gender { get; set; }
    public string MedCouncilNumber { get; set; }
    public string GsmNumber { get; set; }
    public string BordAltranaisNumber { get; set; }

    [NotEmpty(ErrorMessage = "*")] public Guid RoleId { get; set; }
    [NotEmpty(ErrorMessage = "*")] public Guid UserTypeId { get; set; }
    public int OtherField { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; } = null;
}