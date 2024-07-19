using AutoMapper;
using Database;
using Domain.Entities.UserAccounts;
using Microsoft.EntityFrameworkCore;
using Shared.Constants.Role;
using Shared.Helper;
using Shared.Requests.Auth;
using Shared.Requests.UserAccounts;
using Shared.Responses.UserAccounts;
using Shared.State;
using Shared.Wrapper;

namespace Services.Features.UserAccounts.Service;

public class UserService(ApplicationDbContext context, IMapper mapper)
    : IUserService
{

    #region User

    public async Task<Result<LoginResponse>> LoginAsync(LoginRequest request)
    {
        var userInDb = await context.Users.Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Username == request.Username);

        if (userInDb is null)
        {
            return await Result<LoginResponse>.FailAsync("Invalid Credentials");
        }

        if (!userInDb.IsActive || userInDb.IsDeleted)
        {
            return await Result<LoginResponse>.FailAsync("user is deactivated. contact support.");
        }

        var isValid = SecurePasswordHasher.Verify(request.Password, userInDb.PasswordHash);

        if (!isValid) return await Result<LoginResponse>.FailAsync("Invalid Credentials");

        var response = new LoginResponse()
        {
            UserId = userInDb.Id,
            RoleName = userInDb.Role.Name,
            IsForceReset = userInDb.IsForceReset,
            Name = userInDb.FullName
        };
        ApplicationState.CurrentUser = response;
        return await Result<LoginResponse>.SuccessAsync("User Logged in successfully.");
    }

    public async Task<List<UserResponse>> GetUsers()
    {
        var usersList = await context.Users.Include(x => x.Role).Where(x => x.IsDeleted == false)
            .OrderByDescending(x => x.CreatedDate).ToListAsync();
        var users = mapper.Map<List<UserResponse>>(usersList);
        return users;
    }

    public async Task<UserResponse> GetUser(Guid id)
    {
        var userInDb = await context.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Id == id);
        return mapper.Map<UserResponse>(userInDb);
    }

    public async Task<IResult> SaveUser(CreateUserRequest request)
    {
        try
        {
            if (request.Id == Guid.Empty)
            {
                if (context.Users.Any(x => x.Username == request.Username))
                {
                    return await Result.FailAsync("Username already exists.");
                }

                var role = await context.Roles.FirstOrDefaultAsync(x => x.Name == request.UserRole);
                request.Id = Guid.NewGuid();
                request.RoleId = role.Id;
                request.ResetPasswordAt = Method.GetPasswordResetTime(request.ResetPassword);
                request.CreatedBy = ApplicationState.CurrentUser.UserId;
                var hashPassword = SecurePasswordHasher.Hash(request.Password);
                var user = mapper.Map<User>(request);
                user.PasswordHash = hashPassword;
                context.Users.Add(user);
                await context.SaveChangesAsync();
                return await Result.SuccessAsync("User saved");
            }
            else
            {
                if (request.IsUpdatePassword)
                {
                    request.Password = SecurePasswordHasher.Hash(request.Password);
                }

                var role = await context.Roles.FirstOrDefaultAsync(x => x.Name == request.UserRole);
                var userInDb = await context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
                request.RoleId = role.Id;
                request.ModifiedBy = ApplicationState.CurrentUser.UserId;
                request.ModifiedDate = DateTime.Today;
                userInDb = mapper.Map(request, userInDb);
                context.Users.Update(userInDb);
                await context.SaveChangesAsync();
                return await Result.SuccessAsync("User saved");
            }
        }
        catch (Exception e)
        {
            return await Result.FailAsync(e.Message);
        }
    }

    public async Task<IResult> DeleteUser(Guid id)
    {
        var userInDb = await context.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Id == id);
        if (userInDb.Role.Name == RoleConstants.AdministratorRole)
        {
            return await Result.FailAsync("Can't be delete admin user");
        }

        if (userInDb is null)
        {
            return await Result.FailAsync("User not found.");
        }

        userInDb.IsDeleted = true;
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("User has been deleted.");
    }


    public void Logout()
    {
        ApplicationState.CurrentUser = new LoginResponse();
        ApplicationState.IsLoggedIn = false;
    }

    #endregion

    #region Roles

    public async Task<RoleResponse> GetUserRole(Guid roleId)
    {
        var roleInDb = await context.Roles.FirstOrDefaultAsync(x => x.Id == roleId);
        return mapper.Map<RoleResponse>(roleInDb);
    }

    public async Task<Guid> GetRoleId(string name)
    {
        var role = await context.Roles.FirstOrDefaultAsync(x => x.Name == name);
        return role.Id;
    }

    public async Task<List<RoleResponse>> GetRoles()
    {
        var role = await context.Roles.ToListAsync();
        var data = mapper.Map<List<RoleResponse>>(role);
        return data;
    }

    public async Task<IResult> SaveRole(string name, Guid id)
    {
        if (context.Roles.Any(x => x.Name == name))
        {
            return await Result.FailAsync("Role name is already avaialble");
        }

        if (id == Guid.Empty)
        {
            var role = new Role()
            {
                Name = name,
                CreatedBy = ApplicationState.CurrentUser.UserId,
                CreatedDate = DateTime.Today,
            };
            context.Roles.Add(role);
        }
        else
        {
            var roleInDb = await context.Roles.FirstOrDefaultAsync(x => x.Id == id);

            if (roleInDb == null)
                return await Result.FailAsync("Role not found");

            if (roleInDb.IsDefualt)
                return await Result.FailAsync("Default roles can't be update.");


            roleInDb.Name = name;
            roleInDb.ModifiedBy = ApplicationState.CurrentUser.UserId;
            roleInDb.ModifiedDate = DateTime.Today;
        }

        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Role has been saved.");
    }

    public async Task<IResult> DeleteRole(Guid id)
    {
        var roleInDb = await context.Roles.FirstOrDefaultAsync(x => x.Id == id);
        if (roleInDb == null)
            return await Result.FailAsync("Role not found");
        if (roleInDb.IsDefualt)
            return await Result.FailAsync("Default roles can't be delete.");
        context.Roles.Remove(roleInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Role has been deleted.");
    }

    #endregion

    #region Permissions

    public async Task<List<PermissionResponse>> GetPermissions(Guid roleId, string module)
    {
        var permissions = await context.PermissionClaims.Where(x => x.RoleId == roleId && x.ModuleName == module)
            .ToListAsync();
        var data = mapper.Map<List<PermissionResponse>>(permissions);
        return data;
    }

    public async Task<IResult> UpdatePermissions(List<UpdatePermissionRequest> requests)
    {
        foreach (var request in requests)
        {
            var p = await context.PermissionClaims.FirstOrDefaultAsync(x => x.Id == request.Id);
            p.Allowed = request.Value;
            await context.SaveChangesAsync();
        }

        return await Result.SuccessAsync("Permission Updated");
    }

    public async Task<IResult> ResetPassword(ResetPasswordRequest request)
    {
        var userInDb = await context.Users.Include(x => x.Role)
            .FirstOrDefaultAsync(x => x.Id == ApplicationState.CurrentUser.UserId);
        
        if (userInDb == null)
        {
            return await Result.FailAsync("User not found.");
        }

        var hashedPassword = SecurePasswordHasher.Hash(request.NewPassword);
        userInDb.IsForceReset = false;
        userInDb.PasswordHash = hashedPassword;
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Password has been reset");
    }

    #endregion
}