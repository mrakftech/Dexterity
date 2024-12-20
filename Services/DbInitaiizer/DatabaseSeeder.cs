using Bogus;
using Database;
using Domain.Entities.Appointments;
using Domain.Entities.PatientManagement;
using Domain.Entities.PatientManagement.Alert;
using Domain.Entities.PatientManagement.Details;
using Domain.Entities.Settings.Clinic;
using Domain.Entities.Settings.Templates;
using Domain.Entities.Settings.Templates.Dms;
using Domain.Entities.UserAccounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PhoneNumbers;
using Services.Features.Settings.Service;
using Shared.Constants.Application;
using Shared.Constants.Module;
using Shared.Constants.Permission;
using Shared.Constants.Role;
using Shared.Helper;

namespace Services.DbInitaiizer;

public class DatabaseSeeder(
    IDbContextFactory<ApplicationDbContext> contextFactory,
    ILogger<DatabaseSeeder> logger,
    IFileManagerService fileManagerService) : IDatabaseSeeder
{
    public void Initialize()
    {
        SeedClinics();
        SeedRoles();
        SeedUsers();
        SeedAdminPermissions();
        SeedUserPermissions();
        SeedAppointmentTypes();
        SeedAppointmentCancelReasons();
        SeedAlertCategory();
        SeedFakePatientData();
        SeedFakeUserData();
        SeedSketchCategories();
        SeedDmsCategory();

    }
    private void SeedDmsCategory()
    {
        Task.Run(async () =>
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            if (context.DocumentCategories.Any())
                return;
            
            var c = new DocumentCategory()
            {
                Name = "General"
            };
            context.DocumentCategories.Add(c);
            await context.SaveChangesAsync();
        }).GetAwaiter().GetResult();
    }
    private void SeedSketchCategories()
    {
        Task.Run(async () =>
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            if (context.SketchCategories.Any())
                return;

            var parts = new List<SketchCategory>()
            {
                new()
                {
                    Name = "Arm"
                },
                new()
                {
                    Name = "Body"
                },
                new()
                {
                    Name = "Brain"
                },
                new()
                {
                    Name = "Breast"
                },
                new()
                {
                    Name = "Colon"
                },
                new()
                {
                    Name = "Foot"
                },
                new()
                {
                    Name = "Hand"
                },
                new()
                {
                    Name = "Head"
                },
                new()
                {
                    Name = "Hip"
                },
                new()
                {
                    Name = "Knee"
                },
                new()
                {
                    Name = "Leg"
                }
            };
            await context.SketchCategories.AddRangeAsync(parts);
            await context.SaveChangesAsync();
        }).GetAwaiter().GetResult();
    }

    private void SeedAlertCategory()
    {
        Task.Run(async () =>
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            if (context.AlertCategories.Any())
                return;
            var c = new AlertCategory()
            {
                Name = "General"
            };
            context.AlertCategories.Add(c);
            await context.SaveChangesAsync();
        }).GetAwaiter().GetResult();
    }

    private void SeedAppointmentCancelReasons()
    {
        Task.Run(async () =>
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            if (context.AppointmentCancellationReasons.Any())
                return;
            var c = new AppointmentCancellationReason()
            {
                Reason = "Unable to attend",
                IsDefault = true
            };
            context.AppointmentCancellationReasons.Add(c);
            await context.SaveChangesAsync();
        }).GetAwaiter().GetResult();
    }

    private void SeedAppointmentTypes()
    {
        Task.Run(async () =>
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            if (context.AppointmentTypes.Any())
                return;
            var c = new AppointmentType()
            {
                Name = "General",
                Duration = 15,
                Active = true,
            };
            context.AppointmentTypes.Add(c);
            await context.SaveChangesAsync();
        }).GetAwaiter().GetResult();
    }

    private void SeedFakeUserData()
    {
        Task.Run(async () =>
        {
            await using var context = await contextFactory.CreateDbContextAsync();

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
                    .RuleFor(x => x.RoleId, x => x.PickRandom(roleIds))
                    .RuleFor(x => x.IsActive, true)
                    .RuleFor(x => x.PasswordHash, SecurePasswordHasher.Hash(ApplicationConstants.DefaultPassword))
                    .RuleFor(x => x.Phone, x => x.Person.Phone);
                var users = fakeUsers.Generate(10);
                await context.Users.AddRangeAsync(users);
                await context.SaveChangesAsync();
                foreach (var item in users)
                {
                    var userClinic = new UserClinic()
                    {
                        ClinicId = 1,
                        UserId = item.Id
                    };
                    await context.UserClinics.AddAsync(userClinic);
                }

                await context.SaveChangesAsync();
            }
        }).GetAwaiter().GetResult();
    }

    private void SeedFakePatientData()
    {
        Task.Run(async () =>
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            if (context.Patients.Any())
                return;

            if (!context.Patients.Any())
            {
                var address = new PatientAddress() {AddressLine1 = "Testing London"};
                var medical = new MedicalCardDetail() {GmsStatus = "Active", GmsPatientNumber = "M567890A"};
                var clinicId = context.Clinics.FirstOrDefault(x => x.Name == "Clinic").Id;
                var hcpId = context.Users.FirstOrDefault(x => x.FirstName == "User").Id;
                var util = PhoneNumberUtil.GetInstance();
                var num = util.GetExampleNumber("US");
                var fakePatients = new Faker<Patient>()
                    .RuleFor(x => x.Id, x => Guid.NewGuid())
                    .RuleFor(x => x.FamilyName, x => "Test")
                    .RuleFor(x => x.FirstName, x => x.Person.FirstName)
                    .RuleFor(x => x.LastName, x => x.Person.LastName)
                    .RuleFor(x => x.FullName, x => x.Person.FullName)
                    .RuleFor(x => x.DateOfBirth,
                        x => x.Date.Between(new DateTime(1994, 1, 1), new DateTime(2025, 1, 1)))
                    .RuleFor(x => x.Gender, x => x.Person.Gender.ToString())
                    .RuleFor(x => x.Address, x => address)
                    .RuleFor(x => x.MobilePhone, x => util.Format(num, PhoneNumberFormat.E164))
                    .RuleFor(x => x.Email, x => x.Person.Email)
                    .RuleFor(x => x.ClinicId, clinicId)
                    .RuleFor(x => x.HcpId, hcpId)
                    .RuleFor(x => x.MedicalCardDetails, medical)
                    .RuleFor(x => x.UniqueNumber, CryptographyHelper.GetUniqueKey(8))
                    .RuleFor(x => x.MedicalRecordNumber, CryptographyHelper.GenerateMrNumber())
                    .RuleFor(x => x.Status, PatientStatus.Active.ToString())
                    .RuleFor(x => x.PatientType, PatientType.Private.ToString())
                    .RuleFor(x => x.IhiNumber, CryptographyHelper.GetUniqueKey(17))
                    .RuleFor(x => x.CreatedBy, Guid.NewGuid());
                var patients = fakePatients.Generate(20);
                foreach (var patient in patients)
                {
                    await context.Patients.AddAsync(patient);
                    await context.SaveChangesAsync();
                    fileManagerService.CreatePatientDefualtDirectories(patient.Id);
                }
            }
        }).GetAwaiter().GetResult();
    }

    private void SeedAdminPermissions()
    {
        Task.Run(async () =>
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            if (context.PermissionClaims.Any())
                return;
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
            await using var context = await contextFactory.CreateDbContextAsync();
            if (context.PermissionClaims.Any())
                return;
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

    private void SeedClinics()
    {
        Task.Run(async () =>
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            if (context.Clinics.Any())
                return;
            var c = new Clinic()
            {
                Address = "Not set",
                Name = "Clinic"
            };
            context.Clinics.Add(c);
            await context.SaveChangesAsync();
        }).GetAwaiter().GetResult();
    }

    private void SeedUsers()
    {
        Task.Run(async () =>
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            if (context.Users.Any())
                return;
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
                    RoleId = context.Roles.FirstOrDefault(x => x.Name == RoleConstants.AdministratorRole)!.Id,
                    WorkingDays = new List<int> {1, 2, 3},
                    StartHour = new TimeSpan(9, 0, 0),
                    EndHour = new TimeSpan(17, 0, 0)
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
                    WorkingDays = new List<int> {1, 2, 3},
                    StartHour = new TimeSpan(9, 0, 0),
                    EndHour = new TimeSpan(17, 0, 0),
                    RoleId = context.Roles.FirstOrDefault(x => x.Name == RoleConstants.UserRole)!.Id
                },
            };

            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
            foreach (var user in users)
            {
                var clinic = new UserClinic()
                {
                    UserId = user.Id,
                    ClinicId = 1
                };
                context.UserClinics.Add(clinic);
                await context.SaveChangesAsync();
            }

            logger.LogInformation("Users seeded");
        }).GetAwaiter().GetResult();
    }

    private void SeedRoles()
    {
        Task.Run(async () =>
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            if (context.Roles.Any())
                return;

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