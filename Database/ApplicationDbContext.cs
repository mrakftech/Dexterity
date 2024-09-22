using Domain.Entities.Appointments;
using Domain.Entities.Messaging.UserTasks;
using Domain.Entities.Settings.Templates;
using Domain.Entities.UserAccounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Database.Configurations;
using Database.Configurations.AppointmentFluentApi;
using Domain.Entities.Consultation;
using Domain.Entities.PatientManagement.Family;
using Domain.Entities.PatientManagement;
using Domain.Entities.PatientManagement.Alert;
using Domain.Entities.PatientManagement.Allergies;
using Domain.Entities.PatientManagement.Billing;
using Domain.Entities.PatientManagement.Extra;
using Domain.Entities.PatientManagement.Group;
using Domain.Entities.PatientManagement.Options;
using Domain.Entities.Settings.Account;
using Domain.Entities.Settings.Consultation;
using Domain.Entities.Settings.Hospital;
using Domain.Entities.WaitingRoom;

namespace Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    #region Settings

    public DbSet<SmsTemplate> SmsTemplates { get; set; }
    public DbSet<EmailTemplate> EmailTemplates { get; set; }
    public DbSet<Clinic> Clinics { get; set; }
    public DbSet<ClinicSite> ClinicSites { get; set; }
    public DbSet<AppointmentType> AppointmentTypes { get; set; }
    public DbSet<AppointmentCancellationReason> AppointmentCancellationReasons { get; set; }
    public DbSet<AccountType> AccountTypes { get; set; }
    public DbSet<PomrGroup> PomrGroups { get; set; }

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
    public DbSet<PatientTransaction> PatientTransactions { get; set; }
    public DbSet<PatientAccount> PatientAccounts { get; set; }
    public DbSet<Hospital> Hospitals { get; set; }
    public DbSet<PatientAllergy> PatientAllergies { get; set; }
    public DbSet<PatientDrugAllergy> PatientDrugAllergies { get; set; }
    

    #endregion

    #region Appointments

    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<WaitingAppointment> WaitingAppointments { get; set; }

    #endregion

    #region Consultation

    public DbSet<ConsultationDetail> ConsultationDetails { get; set; }
    public DbSet<BaselineDetail> BaselineDetails { get; set; }
    
    public DbSet<Reminder> Reminders { get; set; }

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
        foreach (var property in builder.Model.GetEntityTypes()
                     .SelectMany(t => t.GetProperties())
                     .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        {
            property.SetColumnType("decimal(18,2)");
        }

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
        builder.Entity<PomrGroup>(entity => { entity.ToTable(name: "PomrGroups", "Setting"); });


        builder.Entity<AppointmentCancellationReason>(entity =>
        {
            entity.ToTable(name: "AppointmentCancellationReasons", "Scheduler");
        });

        builder.Entity<WaitingAppointment>(entity =>
        {
            entity.ToTable(name: "WaitingAppointments", "Scheduler");
            entity.HasOne(d => d.Patient)
                .WithMany(p => p.WaitingAppointments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.NoAction);
            entity.HasOne(d => d.Clinic)
                .WithMany(p => p.WaitingAppointments)
                .HasForeignKey(d => d.ClinicId)
                .OnDelete(DeleteBehavior.NoAction);
        });


        builder.Entity<DoctorVisitCard>(entity => { entity.ToTable(name: "DoctorVisitCards", "PM"); });
        builder.Entity<PatientContact>(entity => { entity.ToTable(name: "PatientContacts", "PM"); });
        builder.Entity<PatientOccupation>(
            entity => { entity.ToTable(name: "PatientOccupations", "PM"); });
        builder.Entity<PatientAlert>(entity => { entity.ToTable(name: "PatientAlerts", "PM"); });
        builder.Entity<AlertCategory>(entity => { entity.ToTable(name: "AlertCategories", "PM"); });
        builder.Entity<RelatedHcp>(entity => { entity.ToTable(name: "RelatedHcps", "PM"); });
        builder.Entity<PatientHospital>(entity => { entity.ToTable(name: "PatientHospitals", "PM"); });
        builder.Entity<Group>(entity => { entity.ToTable(name: "Groups", "PM"); });
        builder.Entity<GroupPatient>(entity => { entity.ToTable(name: "GroupPatients", "PM"); });
        builder.Entity<FamilyMember>(entity => { entity.ToTable(name: "FamilyMembers", "PM"); });
        builder.Entity<SmsHistory>(entity => { entity.ToTable(name: "PatientSmsHistories", "PM"); });
        builder.Entity<PatientTransaction>(entity => { entity.ToTable(name: "PatientTransactions", "PM"); });
        builder.Entity<PatientAccount>(entity => { entity.ToTable(name: "PatientAccounts", "PM"); });
        builder.Entity<Hospital>(entity => { entity.ToTable(name: "Hospitals", "PM"); });
        builder.Entity<PatientAllergy>(entity => { entity.ToTable(name: "PatientAllergies", "PM"); });
        builder.Entity<PatientDrugAllergy>(entity => { entity.ToTable(name: "PatientDrugAllergies", "PM"); });


        builder.Entity<ConsultationDetail>(entity => { entity.ToTable(name: "ConsultationDetails", "Consultation"); });
        builder.Entity<BaselineDetail>(entity => { entity.ToTable(name: "BaselineDetails", "Consultation"); });
        builder.Entity<Reminder>(entity => { entity.ToTable(name: "Reminders", "Consultation"); });
    }
}