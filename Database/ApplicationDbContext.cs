﻿using Database.Configurations;
using Database.Configurations.AppointmentFluentApi;
using Domain.Entities.Appointments;
using Domain.Entities.Messaging.UserTasks;
using Domain.Entities.Settings.Templates;
using Domain.Entities.UserAccounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
    public DbSet<HealthCode> Icpc { get; set; }

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
    public DbSet<ConsultationNote> ConsultationNotes { get; set; }

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
        SchemaConfigurations.Configure(builder);
        builder.ApplyConfiguration(new PatientConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new AppointmentConfiguration());
        builder.ApplyConfiguration(new WaitingAppointmentConfiguration());
        builder.ApplyConfiguration(new HealthCodeConfiguration());
        
        foreach (var property in builder.Model.GetEntityTypes()
                     .SelectMany(t => t.GetProperties())
                     .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        {
            property.SetColumnType("decimal(18,2)");
        }
       
    }
}