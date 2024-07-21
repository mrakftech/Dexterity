using Domain.Entities.UserAccounts;
using Services.Contracts.Repositroy;
using Shared.Requests.Auth;
using Shared.Requests.UserAccounts;
using Shared.Responses.UserAccounts;
using Shared.Wrapper;

namespace Services.Features.UserAccounts.Service;

public interface IUserService 
{
    Task<Result<LoginResponse>> LoginAsync(LoginRequest request);

    Task<List<UserResponse>> GetUsers();
    Task<UserResponse> GetUser(Guid id);
    Task<IResult> SaveUser(Guid id,CreateUserRequest request);
    Task<IResult> DeleteUser(Guid id);


    void Logout();


    #region Roles

    Task<List<RoleResponse>> GetRoles();
    Task<IResult> SaveRole(string name, Guid id);
    Task<IResult> DeleteRole(Guid id);

    Task<RoleResponse> GetUserRole(Guid roleId);
    Task<Guid> GetRoleId(string name);

    #endregion

    #region Permissions

    Task<List<PermissionResponse>> GetPermissions(Guid roleId, string module);
    Task<IResult> UpdatePermissions(List<UpdatePermissionRequest> request);
    Task<IResult> ResetPassword(ResetPasswordRequest request);

    #endregion
}