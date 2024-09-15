using Domain.Entities.UserAccounts;
using Services.Features.UserAccounts.Dtos.Auth;
using Services.Features.UserAccounts.Dtos.User;
using Shared.Wrapper;

namespace Services.Features.UserAccounts.Service;

public interface IUserService
{
    Task<Result<LoginResponseDto>> LoginAsync(LoginDto dto);

    Task<List<UserResponseDto>> GetUsers(string usertype=null);
    Task<UserResponseDto> GetUser(Guid id);
    Task<IResult> SaveUser(Guid id, CreateUserDto dto);
    Task<IResult> DeleteUser(Guid id);


    void Logout();


    #region Roles

    Task<List<RoleResponseDto>> GetRoles();
    Task<IResult> SaveRole(string name, Guid id);
    Task<IResult> DeleteRole(Guid id);

    Task<RoleResponseDto> GetUserRole(Guid roleId);
    Task<Guid> GetRoleId(string name);

    #endregion

    #region Permissions

    Task<List<PermissionResponseDto>> GetPermissions(Guid roleId, string module);
    Task<IResult> UpdatePermissions(List<UpdatePermissionDto> request);
    Task<IResult> ResetPassword(ResetPasswordDto dto);

    #endregion

    #region User Clinics
    Task<List<UserClinic>> GetUserClinics(Guid userId);

    Task<IResult> SaveUserClinic(int id, UserClinic request);
    Task<IResult> DeleteClinic(int id);
    Task<List<HealthcareDto>> GetUsersByClinic(int clinicId);
    Task<List<HealthcareDto>> GetDoctors(int clinicId);
    Task<List<HealthcareDto>> GeAlltDoctorsByClinic(int clinicId);

    #endregion
}