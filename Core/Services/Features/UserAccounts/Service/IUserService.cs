using Domain.Entities.UserAccounts;
using Services.Features.UserAccounts.Dtos.Auth;
using Services.Features.UserAccounts.Dtos.User;
using Shared.Wrapper;

namespace Services.Features.UserAccounts.Service;

public interface IUserService
{
    Task<Result<LoginResponseDto>> LoginAsync(LoginDto dto);
    Task<List<UserResponseDto>> GetUsers();
    Task<UserResponseDto> GetUser(Guid id);
    Task<IResult> SaveUser(Guid id, UpdateUserDto dto);
    Task<IResult> DeleteUser(Guid id);
    Task<IResult> UnblockAccount(Guid userId);
    Task<List<Guid>> GetAdminIds();
 

    void Logout();


    #region Roles

    Task<List<RoleResponseDto>> GetRoles();
    Task<IResult> SaveRole(string name, Guid id);
    Task<IResult> DeleteRole(Guid id);

    Task<RoleResponseDto> GetUserRole(Guid roleId);
    Task<Guid> GetRoleId(string name);
    Task<bool> IsAdmin();

    #endregion

    #region Permissions

    bool CheckPermission(string claimName);
    Task<List<PermissionResponseDto>> GetPermissions(Guid roleId, Guid moduleId);
    Task<IResult> UpdatePermissions(List<UpdatePermissionDto> request);
    Task<IResult> ResetPassword(Guid userId,ResetPasswordDto dto);
    Task<IResult> DeleteUserType(Guid id);
    Task<UserType> GetUserType(Guid id);

    #endregion
    
    #region User Types  
    Task<List<UserType>> GetUserTypes();
    Task<IResult> SaveUserType(string name, Guid id);

    #endregion

    #region User Clinics

    Task<List<UserClinic>> GetUserClinics(Guid userId);

    Task<IResult> SaveUserClinic(int id, UserClinic request);
    Task<IResult> DeleteClinic(int id);
    Task<List<HealthcareDto>> GetUsersByClinic(int clinicId);
    Task<List<HealthcareDto>> GetDoctors(int clinicId);

    #endregion
}