using Domain.Entities.Appointments;
using Domain.Entities.Messaging.UserTasks;
using Domain.Entities.Settings.Templates;
using Domain.Entities.UserAccounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Reflection.Emit;
using System.Xml;
using Database.Configurations;
using Database.Configurations.AppointmentFluentApi;
using Domain.Entities.PatientManagement.Family;
using Domain.Entities.PatientManagement;
using Domain.Entities.PatientManagement.Alert;
using Domain.Entities.PatientManagement.Extra;
using Domain.Entities.PatientManagement.Group;
using Domain.Entities.Settings.Account;
using Domain.Entities.Settings.Hospital;

namespace Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    #region Settings

    public DbSet<SmsTemplate> SmsTemplates { get; set; }
    public DbSet<EmailTemplate> EmailTemplates { get; set; }
    public DbSet<Clinic> Clinics { get; set; }
    public DbSet<ClinicSite> ClinicSites { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppointmentType> AppointmentTypes { get; set; }
    public DbSet<AppointmentCancellationReason> AppointmentCancellationReasons { get; set; }
    public DbSet<AccountType> AccountTypes { get; set; }

    #endregion


    #region User

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserClinic> UserClinics { get; set; }
    public DbSet<UserTask> UserTasks { get; set; }
    public DbSet<PermissionClaim> PermissionClaims { get; set; }

    #endregion

    #region Patient

    public DbSet<Patient> Patients { get; set; }
    public DbSet<PatientContact> PatientContacts { get; set; }
    public DbSet<PatientAlert> PatientAlerts { get; set; }
    public DbSet<AlertCategory> AlertCategories { get; set; }
    public DbSet<PatientOccupation> PatientOccupations { get; set; }
    public DbSet<RelatedHcp> RelatedHcps { get; set; }
    public DbSet<PatientHospital> PatientHospitals { get; set; }
    public DbSet<DoctorVisitCard> DoctorVisitCards { get; set; }
    public DbSet<FamilyMember> FamilyMembers { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupPatient> GroupPatients { get; set; }
    public DbSet<SmsHistory> PatientSmsHistories { get; set; }

    #endregion


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder();

        IConfiguration configuration =
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

        optionsBuilder.UseSqlServer(configuration["ConnectionStrings:AppConnection"] ?? string.Empty)
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new PatientConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new AppointmentConfiguration());

        builder.Entity<User>(entity => { entity.ToTable(name: "Users", "Identity"); });
        builder.Entity<Role>(entity => { entity.ToTable(name: "Roles", "Identity"); });
        builder.Entity<PermissionClaim>(entity => { entity.ToTable(name: "Permissions", "Identity"); });
        builder.Entity<UserClinic>(entity => { entity.ToTable(name: "UserClinics", "Identity"); });


        builder.Entity<UserTask>(entity => { entity.ToTable(name: "UserTasks", "Messaging"); });

        
        builder.Entity<EmailTemplate>(entity => { entity.ToTable(name: "EmailTemplates", "Setting"); });
        builder.Entity<SmsTemplate>(entity => { entity.ToTable(name: "SmsTemplates", "Setting"); });
        builder.Entity<Clinic>(entity => { entity.ToTable(name: "Clinic", "Setting"); });
        builder.Entity<ClinicSite>(entity => { entity.ToTable(name: "ClinicSites", "Setting"); });
        builder.Entity<AppointmentType>(entity => { entity.ToTable(name: "AppointmentTypes", "Scheduler"); });
        builder.Entity<AccountType>(entity => { entity.ToTable(name: "AccountTypes", "Setting"); });


        builder.Entity<AppointmentCancellationReason>(entity =>
        {
            entity.ToTable(name: "AppointmentCancellationReasons", "Scheduler");
        });


        builder.Entity<DoctorVisitCard>(entity => { entity.ToTable(name: "DoctorVisitCards", "PatientManagement"); });
        builder.Entity<PatientContact>(entity => { entity.ToTable(name: "PatientContacts", "PatientManagement"); });
        builder.Entity<PatientOccupation>(
            entity => { entity.ToTable(name: "PatientOccupations", "PatientManagement"); });
        builder.Entity<PatientAlert>(entity => { entity.ToTable(name: "PatientAlerts", "PatientManagement"); });
        builder.Entity<AlertCategory>(entity => { entity.ToTable(name: "AlertCategories", "PatientManagement"); });
        builder.Entity<RelatedHcp>(entity => { entity.ToTable(name: "RelatedHcps", "PatientManagement"); });
        builder.Entity<PatientHospital>(entity => { entity.ToTable(name: "PatientHospitals", "PatientManagement"); });
        builder.Entity<Group>(entity => { entity.ToTable(name: "Groups", "PatientManagement"); });
        builder.Entity<GroupPatient>(entity => { entity.ToTable(name: "GroupPatients", "PatientManagement"); });
        builder.Entity<FamilyMember>(entity => { entity.ToTable(name: "FamilyMembers", "PatientManagement"); });
        builder.Entity<SmsHistory>(entity => { entity.ToTable(name: "PatientSmsHistories", "PatientManagement"); });
    }
}