using AutoMapper;
using Database;
using Domain.Entities.UserAccounts;
using Microsoft.EntityFrameworkCore;
using Services.Features.UserAccounts.Dtos.Auth;
using Services.Features.UserAccounts.Dtos.User;
using Services.State;
using Shared.Constants.Role;
using Shared.Helper;
using Shared.Wrapper;

namespace Services.Features.UserAccounts.Service;

public class UserService(ApplicationDbContext context, IMapper mapper)
    : IUserService
{
    #region User

    public async Task<Result<LoginResponseDto>> LoginAsync(LoginDto dto)
    {
        var userInDb = await context.Users.Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Username == dto.Username);

        if (userInDb is null)
        {
            return await Result<LoginResponseDto>.FailAsync("Invalid Credentials");
        }

        if (!userInDb.IsActive || userInDb.IsDeleted)
        {
            return await Result<LoginResponseDto>.FailAsync("user is deactivated. contact support.");
        }

        var isValid = SecurePasswordHasher.Verify(dto.Password, userInDb.PasswordHash);

        if (!isValid) return await Result<LoginResponseDto>.FailAsync("Invalid Credentials");

        var response = new LoginResponseDto()
        {
            UserId = userInDb.Id,
            RoleName = userInDb.Role.Name,
            IsForceReset = userInDb.IsForceReset,
            Name = userInDb.FullName
        };
        ApplicationState.CurrentUser = response;
        return await Result<LoginResponseDto>.SuccessAsync("User Logged in successfully.");
    }

    public async Task<List<UserResponseDto>> GetUsers()
    {
        var usersList = await context.Users.Include(x => x.Role).Where(x => x.IsDeleted == false)
            .OrderByDescending(x => x.CreatedDate).ToListAsync();
        var users = mapper.Map<List<UserResponseDto>>(usersList);
        return users;
    }

    public async Task<UserResponseDto> GetUser(Guid id)
    {
        var userInDb = await context.Users
            .Include(x => x.Role)
            .Include(x => x.UserClinics)
            .FirstOrDefaultAsync(x => x.Id == id);

        return mapper.Map<UserResponseDto>(userInDb);
    }

    public async Task<IResult> SaveUser(Guid id, CreateUserDto dto)
    {
        try
        {
            if (id == Guid.Empty)
            {
                if (context.Users.Any(x => x.Username == dto.Username))
                {
                    return await Result.FailAsync("Username already exists.");
                }

                dto.RoleId = dto.RoleId;
                dto.ResetPasswordAt = Method.GetPasswordResetTime(dto.ResetPassword);
                dto.CreatedBy = ApplicationState.CurrentUser.UserId;
                var hashPassword = SecurePasswordHasher.Hash(dto.Password);
                var user = mapper.Map<User>(dto);
                user.PasswordHash = hashPassword;
                context.Users.Add(user);
                await context.SaveChangesAsync();
                return await Result.SuccessAsync("User saved");
            }
            else
            {
                if (dto.IsUpdatePassword)
                {
                    dto.Password = SecurePasswordHasher.Hash(dto.Password);
                }

                var userInDb = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
                dto.RoleId = dto.RoleId;
                dto.ModifiedBy = ApplicationState.CurrentUser.UserId;
                dto.ModifiedDate = DateTime.Today;
                dto.ResetPasswordAt = Method.GetPasswordResetTime(dto.ResetPassword);
                userInDb = mapper.Map(dto, userInDb);
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
        ApplicationState.CurrentUser = new LoginResponseDto();
        ApplicationState.IsLoggedIn = false;
    }

    #endregion

    #region Roles

    public async Task<RoleResponseDto> GetUserRole(Guid roleId)
    {
        var roleInDb = await context.Roles.FirstOrDefaultAsync(x => x.Id == roleId);
        return mapper.Map<RoleResponseDto>(roleInDb);
    }

    public async Task<Guid> GetRoleId(string name)
    {
        var role = await context.Roles.FirstOrDefaultAsync(x => x.Name == name);
        return role.Id;
    }

    public async Task<List<RoleResponseDto>> GetRoles()
    {
        var role = await context.Roles.ToListAsync();
        var data = mapper.Map<List<RoleResponseDto>>(role);
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

    public async Task<List<PermissionResponseDto>> GetPermissions(Guid roleId, string module)
    {
        var permissions = await context.PermissionClaims.Where(x => x.RoleId == roleId && x.ModuleName == module)
            .ToListAsync();
        var data = mapper.Map<List<PermissionResponseDto>>(permissions);
        return data;
    }

    public async Task<IResult> UpdatePermissions(List<UpdatePermissionDto> requests)
    {
        foreach (var request in requests)
        {
            var p = await context.PermissionClaims.FirstOrDefaultAsync(x => x.Id == request.Id);
            p.Allowed = request.Value;
            await context.SaveChangesAsync();
        }

        return await Result.SuccessAsync("Permission Updated");
    }

    public async Task<IResult> ResetPassword(ResetPasswordDto dto)
    {
        var userInDb = await context.Users.Include(x => x.Role)
            .FirstOrDefaultAsync(x => x.Id == ApplicationState.CurrentUser.UserId);

        if (userInDb == null)
        {
            return await Result.FailAsync("User not found.");
        }

        var hashedPassword = SecurePasswordHasher.Hash(dto.NewPassword);
        userInDb.IsForceReset = false;
        userInDb.PasswordHash = hashedPassword;
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Password has been reset");
    }

    #endregion

    #region User Clinic

    public async Task<List<UserClinic>> GetUserClinics(Guid userId)
    {
        return await context.UserClinics
            .Where(x => x.UserId == userId)
            .Include(x => x.Clinic).ToListAsync();
    }

    public async Task<IResult> SaveUserClinic(int id, UserClinic request)
    {
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
        var users = await context.UserClinics
            .Where(x => x.ClinicId == clinicId)
            .Select(x => x.User)
            .ToListAsync();
        foreach (var user in users)
        {
            var data = mapper.Map<HealthcareDto>(user);
            //Excluding logged in user.
            if (data.Id != ApplicationState.CurrentUser.UserId)
            {
                list.Add(data);
            }
        }

        return list;
    }

    #endregion
}