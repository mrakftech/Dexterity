using Bogus;
using Database;
using Domain.Entities.PatientManagement;
using Domain.Entities.UserAccounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PhoneNumbers;
using Shared.Constants.Application;
using Shared.Constants.Module;
using Shared.Constants.Permission;
using Shared.Constants.Role;
using Shared.Helper;

namespace Services.DbInitaiizer;

public class DatabaseSeeder(
    ApplicationDbContext context,
    ILogger<DatabaseSeeder> logger) : IDatabaseSeeder
{
    public void Initialize()
    {
        if (!context.Roles.Any())
        {
            SeedRoles();
        }

        if (!context.Users.Any())
        {
            SeedUsers();
        }


        if (!context.PermissionClaims.Any())
        {
            SeedAdminPermissions();
            SeedUserPermissions();
        }

        //SeedFakePatientData();
      //  SeedFakeUserData();
    }

    private void SeedFakeUserData()
    {
        Task.Run(async () =>
        {
            var userTypes = UserTypeConstants.UserTypes as IEnumerable<string>;
            var roleIds = context.Roles.Select(x => x.Id).ToList();
            if (context.Users.Count() == 2)
            {
                var fakeUsers = new Faker<User>()
                    .RuleFor(x => x.CreatedDate,
                        x => x.Date.Between(new DateTime(2020, 1, 1), new DateTime(2025, 1, 1)))
                    .RuleFor(x => x.FirstName, x => x.Person.FirstName)
                    .RuleFor(x => x.LastName, x => x.Person.LastName)
                    .RuleFor(x => x.FullName, x => x.Person.FullName)
                    .RuleFor(x => x.Username, x => x.Person.UserName)
                    .RuleFor(x => x.Email, x => x.Person.Email)
                    .RuleFor(x => x.ModifiedDate, DateTime.Today)
                    .RuleFor(x => x.Mcn, x => x.Phone.PhoneNumber())
                    .RuleFor(x => x.UserType, x => x.PickRandom(userTypes))
                    .RuleFor(x => x.RoleId, x => x.PickRandom(roleIds))
                    .RuleFor(x => x.IsActive, true)
                    .RuleFor(x => x.PasswordHash, SecurePasswordHasher.Hash(ApplicationConstants.DefaultPassword))
                    .RuleFor(x => x.Phone, x => x.Person.Phone);
                var user = fakeUsers.Generate(150);
                await context.Users.AddRangeAsync(user);
                await context.SaveChangesAsync();
            }
        }).GetAwaiter().GetResult();
    }

    private void SeedFakePatientData()
    {
        Task.Run(async () =>
        {
            if (!context.Patients.Any())
            {
                var util = PhoneNumberUtil.GetInstance();
                var num = util.GetExampleNumber("US");
                var types = PatientConstants.PatientTypes;
                var fakePatients = new Faker<Patient>()
                    .RuleFor(x => x.FirstName, x => x.Person.FirstName)
                    .RuleFor(x => x.LastName, x => x.Person.LastName)
                    .RuleFor(x => x.FullName, x => x.Person.FullName)
                    .RuleFor(x => x.DateOfBirth, x => DateOnly.FromDateTime(x.Person.DateOfBirth))
                    .RuleFor(x => x.Gender, x => x.Person.Gender.ToString())
                    .RuleFor(x => x.AddressLine1, x => x.Address.FullAddress())
                    .RuleFor(x => x.Mobile, x => util.Format(num, PhoneNumberFormat.E164))
                    .RuleFor(x => x.HomePhone, x => x.Phone.PhoneNumber())
                    .RuleFor(x => x.EmailAddress, x => x.Person.Email)
                    .RuleFor(x => x.PatientStatus, "Active")
                    .RuleFor(x => x.IhINumber, x => x.Random.Number(1, 2000000000).ToString())
                    .RuleFor(x => x.UniqueNumber, x => x.Random.Number(1, 2000000000).ToString())
                    .RuleFor(x => x.Ppsn, x => x.Random.Number(1, 1500000000).ToString())
                    .RuleFor(x => x.PatientType, x => x.PickRandom(types))
                    .RuleFor(x => x.City, x => x.Address.City())
                    .RuleFor(x => x.Title, x => x.Name.Prefix())
                    .RuleFor(x => x.Country, x => x.Address.Country())
                    .RuleFor(x => x.CreatedBy, Guid.NewGuid());
                var patients = fakePatients.Generate(500);
                await context.Patients.AddRangeAsync(patients);
                await context.SaveChangesAsync();
            }
        }).GetAwaiter().GetResult();
    }

    private void SeedAdminPermissions()
    {
        Task.Run(async () =>
        {
            var list = new List<PermissionClaim>();
            var role = await context.Roles.FirstOrDefaultAsync(x => x.Name == RoleConstants.AdministratorRole);
            foreach (var module in PermissionConstants.Modules)
            {
                foreach (var claim in PermissionConstants.AllClaims)
                {
                    var permissionClaim = new PermissionClaim();
                    permissionClaim.ModuleName = module;
                    permissionClaim.RoleId = role.Id;
                    permissionClaim.ClaimName = claim;
                    permissionClaim.Allowed = true;
                    list.Add(permissionClaim);
                }
            }

            await context.PermissionClaims.AddRangeAsync(list);
            await context.SaveChangesAsync();
        }).GetAwaiter().GetResult();
    }

    private void SeedUserPermissions()
    {
        Task.Run(async () =>
        {
            var list = new List<PermissionClaim>();
            var role = await context.Roles.FirstOrDefaultAsync(x => x.Name == RoleConstants.UserRole);
            foreach (var module in PermissionConstants.Modules)
            {
                foreach (var claim in PermissionConstants.AllClaims)
                {
                    var permissionClaim = new PermissionClaim();
                    permissionClaim.ModuleName = module;
                    permissionClaim.RoleId = role.Id;
                    permissionClaim.ClaimName = claim;
                    permissionClaim.Allowed = false;
                    list.Add(permissionClaim);
                }
            }

            await context.PermissionClaims.AddRangeAsync(list);
            await context.SaveChangesAsync();
        }).GetAwaiter().GetResult();
    }

    private void SeedUsers()
    {
        Task.Run(async () =>
        {
            var passHash = SecurePasswordHasher.Hash(ApplicationConstants.DefaultPassword);
            var users = new List<User>()
            {
                new()
                {
                    Username = "admin@dexterity",
                    Email = "admin@dexterity.com",
                    FirstName = "Admin",
                    LastName = "Dexterity",
                    Phone = "123589641",
                    IsActive = true,
                    Mcn = "00000000",
                    Ban = "00000000",
                    UserType = UserTypeConstants.Doctor,
                    PasswordHash = passHash,
                    RoleId = context.Roles.FirstOrDefault(x => x.Name == RoleConstants.AdministratorRole)!.Id
                },
                new()
                {
                    Username = "user@dexterity",
                    Email = "user@dexterity.com",
                    FirstName = "User",
                    LastName = "Dexterity",
                    IsActive = true,
                    Phone = "123589641",
                    Mcn = "00000000",
                    Ban = "00000000",
                    UserType = UserTypeConstants.Doctor,
                    PasswordHash = passHash,
                    RoleId = context.Roles.FirstOrDefault(x => x.Name == RoleConstants.UserRole)!.Id
                },
            };

            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
            logger.LogInformation("Users seeded");
        }).GetAwaiter().GetResult();
    }

    private void SeedRoles()
    {
        Task.Run(async () =>
        {
            var roles = new List<Role>()
            {
                new()
                {
                    CreatedDate = DateTime.Today,
                    Name = RoleConstants.SuperAdministrator,
                    IsDefualt = true
                },
                new()
                {
                    CreatedDate = DateTime.Today,
                    Name = RoleConstants.AdministratorRole,
                    IsDefualt = true
                },
                new()
                {
                    CreatedDate = DateTime.Today,
                    Name = RoleConstants.UserRole,
                    IsDefualt = true
                },
                new()
                {
                    CreatedDate = DateTime.Today,
                    Name = RoleConstants.Doctor,
                    IsDefualt = true
                },
                new()
                {
                    CreatedDate = DateTime.Today,
                    Name = RoleConstants.Nurse,
                    IsDefualt = true
                },
                new()
                {
                    CreatedDate = DateTime.Today,
                    Name = RoleConstants.Receptionist,
                    IsDefualt = true
                }
            };

            await context.Roles.AddRangeAsync(roles);
            await context.SaveChangesAsync();
            logger.LogInformation("Roles seeded");
        }).GetAwaiter().GetResult();
    }
}