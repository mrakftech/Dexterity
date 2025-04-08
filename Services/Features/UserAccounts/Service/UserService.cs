using AutoMapper;
using Database;
using Domain.Entities.UserAccounts;
using Microsoft.EntityFrameworkCore;
using Services.Features.Appointments.Dtos.Availability;
using Services.Features.UserAccounts.Dtos.Auth;
using Services.Features.UserAccounts.Dtos.User;
using Services.State;
using Shared.Constants.Application;
using Shared.Constants.Permission;
using Shared.Constants.Role;
using Shared.Helper;
using Shared.Wrapper;

namespace Services.Features.UserAccounts.Service;

public class UserService(IMapper mapper, IDbContextFactory<ApplicationDbContext> contextFactory)
    : IUserService
{
    #region User

    public async Task<Result<LoginResponseDto>> LoginAsync(LoginDto dto)
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        var userInDb = await context.Users.Include(x => x.Role)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Username == dto.Username);

        if (userInDb is null)
        {
            return await Result<LoginResponseDto>.FailAsync("Invalid Credentials");
        }

        if (userInDb.IsLockOut)
        {
            return await Result<LoginResponseDto>.FailAsync("user account is lockout. contact support.");
        }

        if (!userInDb.IsActive || userInDb.IsDeleted)
        {
            return await Result<LoginResponseDto>.FailAsync("user is deactivated. contact support.");
        }

        var isValid = SecurePasswordHasher.Verify(dto.Password, userInDb.PasswordHash);

        if (!isValid)
        {
            if (userInDb.Role.Name != RoleConstants.AdministratorRole)
            {
                //updating failed attempted
                await UpdateFailedAttempted(userInDb.Id);
            }

            return await Result<LoginResponseDto>.FailAsync("Invalid Credentials");
        }

        var response = new LoginResponseDto()
        {
            UserId = userInDb.Id,
            RoleName = userInDb.Role.Name,
            IsForceReset = userInDb.IsForceReset,
            Name = userInDb.FullName,
            WorkingDays = userInDb.WorkingDays,
            StartHour = userInDb.StartHour,
            EndHour = userInDb.EndHour,
            RoleId = userInDb.RoleId,
            ResetPasswordAt = userInDb.ResetPasswordAt,
        };
        ApplicationState.Auth.CurrentUser = response;
        ApplicationState.Auth.CurrentUser.IsAdmin = await IsAdmin();
        ApplicationState.Auth.CurrentUser.PermissionClaims = await GetPermissionsByRoles(response.RoleId);
        //reseting failed attempted
        await ResetFailedAttempted(userInDb.Id);
        return await Result<LoginResponseDto>.SuccessAsync("User Logged in successfully.");
    }

    public async Task<List<UserResponseDto>> GetUsers()
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        var userList = await context.Users
            .Include(x => x.Role)
            .Include(x => x.UserType)
            .Include(x => x.UserClinics)
            .Where(x => x.IsDeleted == false)
            .OrderByDescending(x => x.CreatedDate)
            .ToListAsync();
        var users = mapper.Map<List<UserResponseDto>>(userList);
        return users;
    }

    public async Task<UserResponseDto> GetUser(Guid id)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        var userInDb = await context.Users
            .Include(x => x.Role)
            .Include(x => x.UserClinics)
            .FirstOrDefaultAsync(x => x.Id == id);

        return mapper.Map<UserResponseDto>(userInDb);
    }

    public async Task<IResult> SaveUser(Guid id, UpdateUserDto request)
    {
        try
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            if (id == Guid.Empty)
            {
                if (context.Users.Any(x => x.Username == request.Username))
                {
                    return await Result.FailAsync("Username already exists.");
                }

                request.RoleId = request.RoleId;
                request.ResetPasswordAt = DexHelperMethod.GetPasswordResetTime(request.ResetPassword);
                request.ResetPassword = request.ResetPassword;
                request.CreatedBy = ApplicationState.Auth.CurrentUser.UserId;
                var hashPassword = SecurePasswordHasher.HashPassword(ApplicationConstants.DefaultPassword);
                var user = mapper.Map<User>(request);
                user.PasswordHash = hashPassword;


                context.Users.Add(user);
            }
            else
            {
                var userInDb = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
                request.RoleId = request.RoleId;
                request.ModifiedBy = ApplicationState.Auth.CurrentUser.UserId;
                request.ModifiedDate = DateTime.Today;
                request.ResetPasswordAt = DexHelperMethod.GetPasswordResetTime(request.ResetPassword);
                userInDb = mapper.Map(request, userInDb);
                if (request.IsUpdatePassword)
                {
                    userInDb.PasswordHash = SecurePasswordHasher.HashPassword(ApplicationConstants.DefaultPassword);
                }

                context.Users.Update(userInDb);
            }

            await context.SaveChangesAsync();
            return await Result.SuccessAsync("User saved");
        }
        catch (Exception e)
        {
            return await Result.FailAsync(e.Message);
        }
    }

    public async Task<IResult> DeleteUser(Guid id)
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        var userInDb = await context.Users
            .Include(x => x.Role)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
        if (userInDb is null)
        {
            return await Result.FailAsync("User not found.");
        }

        if (userInDb.Role.Name == RoleConstants.AdministratorRole)
        {
            return await Result.FailAsync("Can't be delete admin user");
        }


        userInDb.IsDeleted = true;
        context.Users.Update(userInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("User has been deleted.");
    }

    public async Task<IResult> UnblockAccount(Guid userId)
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        var userInDb = await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == userId);
        if (userInDb is null)
        {
            return await Result.FailAsync("User not found.");
        }

        userInDb.IsLockOut = false;
        userInDb.FailedAttempted = 0;
        userInDb.IsForceReset = true;
        context.ChangeTracker.Clear();
        context.Users.Update(userInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("User is Unlocked.");
    }

    public async Task<List<Guid>> GetAdminIds()
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        var adminRole = await context.Roles.FirstOrDefaultAsync(x => x.Name == RoleConstants.AdministratorRole);
        return await context.Users
            .Where(x => x.RoleId == adminRole.Id)
            .Select(x => x.Id).ToListAsync();
    }


    public void Logout()
    {
        ApplicationState.Auth.CurrentUser = new LoginResponseDto();
        ApplicationState.Auth.IsLoggedIn = false;
    }

    #endregion

    #region Roles

    public async Task<RoleResponseDto> GetUserRole(Guid roleId)
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        var roleInDb = await context.Roles.FirstOrDefaultAsync(x => x.Id == roleId);
        return mapper.Map<RoleResponseDto>(roleInDb);
    }

    public async Task<Guid> GetRoleId(string name)
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        var role = await context.Roles.FirstOrDefaultAsync(x => x.Name == name);
        return role.Id;
    }

    public async Task<bool> IsAdmin()
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        var isAdmin = await context.Roles.FirstOrDefaultAsync(x =>
            x.Id == ApplicationState.Auth.CurrentUser.RoleId && x.Name == RoleConstants.AdministratorRole);
        return isAdmin is not null;
    }


    public async Task<List<RoleResponseDto>> GetRoles()
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        var role = await context.Roles.ToListAsync();
        var data = mapper.Map<List<RoleResponseDto>>(role);
        return data;
    }


    public async Task<IResult> SaveRole(string name, Guid id)
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        if (context.Roles.Any(x => x.Name == name))
        {
            return await Result.FailAsync("Role name is already avaialble");
        }

        if (id == Guid.Empty)
        {
            var role = new Role()
            {
                Name = name,
                CreatedBy = ApplicationState.Auth.CurrentUser.UserId,
                CreatedDate = DateTime.Today,
            };
            context.Roles.Add(role);
            await AddPermissions(role.Name);
        }
        else
        {
            var roleInDb = await context.Roles.FirstOrDefaultAsync(x => x.Id == id);

            if (roleInDb == null)
                return await Result.FailAsync("Role not found");

            if (roleInDb.IsDefualt)
                return await Result.FailAsync("Default roles can't be update.");


            roleInDb.Name = name;
            roleInDb.ModifiedBy = ApplicationState.Auth.CurrentUser.UserId;
            roleInDb.ModifiedDate = DateTime.Today;
        }

        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Role has been saved.");
    }

    public async Task<IResult> DeleteRole(Guid id)
    {
        await using var context = await contextFactory.CreateDbContextAsync();

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

    #region Persmissions

    private async Task AddPermissions(string roleName)
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        var list = new List<PermissionClaim>();
        var role = await context.Roles.FirstOrDefaultAsync(x => x.Name == roleName);
        var modules = await context.AppModules.OrderBy(x => x.Order).ToListAsync();
        foreach (var module in modules)
        {
            foreach (var claim in PermissionConstants.AllClaims)
            {
                var permissionClaim = new PermissionClaim
                {
                    ModuleName = module.Name,
                    ModuleId = module.Id,
                    RoleId = role.Id,
                    ClaimName = claim,
                    Allowed = false
                };
                list.Add(permissionClaim);
            }
        }

        await context.PermissionClaims.AddRangeAsync(list);
    }
    private async Task<List<PermissionClaim>> GetPermissionsByRoles(Guid roleId)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        return await context.PermissionClaims.Where(x => x.RoleId == roleId).ToListAsync();
    }
    public bool CheckPermission(string claimName)
    {
        var permissionClaim = ApplicationState.Auth.CurrentUser.PermissionClaims.FirstOrDefault(x =>
            x.RoleId == ApplicationState.Auth.CurrentUser.RoleId &&
            x.ModuleId == ApplicationState.Auth.SelectedModuleId && x.ClaimName == claimName);
        return permissionClaim is not null && permissionClaim.Allowed;
    }

   

    public async Task<List<PermissionResponseDto>> GetPermissions(Guid roleId, Guid moduleId)
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        var permissions = await context.PermissionClaims.AsNoTracking()
            .Where(x => x.RoleId == roleId && x.ModuleId == moduleId)
            .ToListAsync();
        var data = mapper.Map<List<PermissionResponseDto>>(permissions);
        return data;
    }

    public async Task<IResult> UpdatePermissions(List<UpdatePermissionDto> requests)
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        foreach (var request in requests)
        {
            var p = await context.PermissionClaims.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);
            p.Allowed = request.Value;
            context.ChangeTracker.Clear();
            context.PermissionClaims.Update(p);
            await context.SaveChangesAsync();
        }

        return await Result.SuccessAsync("Permission Updated");
    }

    public async Task<IResult> ResetPassword(Guid userId, ResetPasswordDto dto)
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        var userInDb = await context.Users.Include(x => x.Role)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == userId);

        if (userInDb == null)
        {
            return await Result.FailAsync("User not found.");
        }

        var hashedPassword = SecurePasswordHasher.HashPassword(dto.NewPassword);
        userInDb.IsForceReset = false;
        userInDb.PasswordHash = hashedPassword;
        userInDb.ResetPasswordAt = DexHelperMethod.GetPasswordResetTime(userInDb.ResetPassword);
        context.ChangeTracker.Clear();
        context.Users.Update(userInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Password has been reset");
    }

    #endregion

    #region User Types

    public async Task<List<UserType>> GetUserTypes()
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        return await context.UserTypes.ToListAsync();
    }

    public async Task<IResult> SaveUserType(string name, Guid id)
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        if (context.UserTypes.Any(x => x.Name == name))
        {
            return await Result.FailAsync("Role name is already avaialble");
        }

        if (id == Guid.Empty)
        {
            var userType = new UserType()
            {
                Name = name,
            };
            context.UserTypes.Add(userType);
        }
        else
        {
            var userType = await context.UserTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (userType == null)
                return await Result.FailAsync("User type not found");

            if (userType.IsDefualt)
                return await Result.FailAsync("Default user type can't be update.");


            userType.Name = name;
            context.UserTypes.Update(userType);
        }

        await context.SaveChangesAsync();
        return await Result.SuccessAsync("User Type has been saved.");
    }

    public async Task<IResult> DeleteUserType(Guid id)
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        var userType = await context.UserTypes.FirstOrDefaultAsync(x => x.Id == id);
        if (userType == null)
            return await Result.FailAsync("User Type not found");
        if (userType.IsDefualt)
            return await Result.FailAsync("Default user Type can't be delete.");
        context.UserTypes.Remove(userType);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("User Type has been deleted.");
    }

    public async Task<UserType> GetUserType(Guid id)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        return await context.UserTypes.FirstOrDefaultAsync(x => x.Id == id);
    }

    #endregion

    #region User Clinic

    public async Task<List<UserClinic>> GetUserClinics(Guid userId)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        return await context.UserClinics.Include(x => x.Clinic)
            .Where(x => x.UserId == userId)
            .Include(x => x.Clinic).ToListAsync();
    }

    public async Task<IResult> SaveUserClinic(int id, UserClinic request)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        if (id == 0)
        {
            if (context.UserClinics.Any(x => x.ClinicId == request.ClinicId && x.UserId == request.UserId))
                return await Result.FailAsync("Clinic already exists.");

            await context.UserClinics.AddAsync(request);
        }
        else
        {
            var clinic = context.UserClinics.FirstOrDefault(x => x.Id == id);

            if (clinic == null)
                return await Result.FailAsync("clinic not found.");

            context.UserClinics.Update(request);
        }

        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Clinic saved.");
    }

    public async Task<IResult> DeleteClinic(int id)
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        var clinic = context.UserClinics.FirstOrDefault(x => x.Id == id);
        if (clinic == null)
            return await Result.FailAsync("clinic not found.");

        context.UserClinics.Remove(clinic);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("User Clinic deleted.");
    }

    public async Task<List<HealthcareDto>> GetUsersByClinic(int clinicId)
    {
        var list = new List<HealthcareDto>();
        await using var context = await contextFactory.CreateDbContextAsync();

        var users = await context.UserClinics
            .AsNoTracking()
            .Where(x => x.ClinicId == clinicId)
            .Select(x => x.User)
            .ToListAsync();

        foreach (var user in users)
        {
            var data = mapper.Map<HealthcareDto>(user);
            list.Add(data);
        }

        return list;
    }

    public async Task<List<HealthcareDto>> GetDoctors(int clinicId)
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        var userTypeId = await GetUserType(UserTypeConstants.Doctor);
        var users = await context.UserClinics
            .AsNoTracking()
            .Where(x => x.ClinicId == clinicId)
            .Include(x => x.User.UserType)
            .Select(x => x.User)
            .ToListAsync();

        return users.Where(x => x.UserTypeId == userTypeId).Select(mapper.Map<HealthcareDto>)
            .ToList();
    }

    #endregion

    #region Private Methods

    private async Task<Guid> GetUserType(string userType)
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        var userTypeInDb = await context.UserTypes.FirstOrDefaultAsync(x => x.Name == userType);
        return userTypeInDb?.Id ?? Guid.Empty;
    }

    private async Task UpdateFailedAttempted(Guid userId)
    {
        try
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var user = await context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == userId);
            if (user is not null)
            {
                if (user.FailedAttempted == 5)
                {
                    user.IsLockOut = true;
                }
                else
                {
                    user.FailedAttempted++;
                }

                context.ChangeTracker.Clear();
                context.Users.Update(user);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task ResetFailedAttempted(Guid userId)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        var user = await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == userId);
        if (user is not null)
        {
            user.FailedAttempted = 0;
            user.IsLockOut = false;
            context.ChangeTracker.Clear();
            context.Users.Update(user);
            await context.SaveChangesAsync();
        }
    }

    #endregion
}