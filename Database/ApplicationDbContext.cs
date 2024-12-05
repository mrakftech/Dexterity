using Database.Configurations;
using Database.Configurations.AppointmentFluentApi;
using Domain.Entities.Appointments;
using Domain.Entities.Settings.Templates;
using Domain.Entities.UserAccounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Domain.Entities.Consultation;
using Domain.Entities.Consultation.Common;
using Domain.Entities.Consultation.Detail;
using Domain.Entities.Consultation.Documents;
using Domain.Entities.Consultation.Immunisations;
using Domain.Entities.Consultation.InvestigationDetails;
using Domain.Entities.Consultation.Notes;
using Domain.Entities.Messaging;
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
using Domain.Entities.WaitingRoom;
using Domain.Entities.Settings.Clinic;
using Domain.Entities.Settings.Consultation.Immunisation;
using Domain.Entities.Settings.Drugs;
using Domain.Entities.Settings.Templates.InvestigationTemplates;
using Domain.Entities.Settings.Templates.Letter;

namespace Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder();

        IConfiguration configuration =
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

        optionsBuilder
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .UseSqlServer(configuration["ConnectionStrings:AppConnection"] ?? string.Empty);

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

        builder.Entity<ChatMessage>(entity =>
        {
            entity.HasOne(d => d.FromUser)
                .WithMany(p => p.ChatMessagesFromUsers)
                .HasForeignKey(d => d.FromUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            entity.HasOne(d => d.ToUser)
                .WithMany(p => p.ChatMessagesToUsers)
                .HasForeignKey(d => d.ToUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });
    }

    #region Settings

    public DbSet<SmsTemplate> SmsTemplates { get; set; }
    public DbSet<EmailTemplate> EmailTemplates { get; set; }
    public DbSet<LetterType> LetterTypes { get; set; }
    public DbSet<LetterTemplate> LetterTemplates { get; set; }
    public DbSet<Clinic> Clinics { get; set; }
    public DbSet<ClinicSite> ClinicSites { get; set; }
    public DbSet<AppointmentType> AppointmentTypes { get; set; }
    public DbSet<AppointmentCancellationReason> AppointmentCancellationReasons { get; set; }
    public DbSet<AccountType> AccountTypes { get; set; }
    public DbSet<PomrGroup> PomrGroups { get; set; }
    public DbSet<HealthCode> HealthConditionCodes { get; set; }
    public DbSet<NoteTemplate> NoteTemplates { get; set; }
    public DbSet<Drug> Drugs { get; set; }
    public DbSet<Investigation> Investigations { get; set; }
    public DbSet<InvestigationDetail> InvestigationDetails { get; set; }
    public DbSet<InvestigationSelectionList> InvestigationSelectionList { get; set; }
    public DbSet<InvestigationSelectionValue> InvestigationSelectionValues { get; set; }
    public DbSet<InvestigationGroup> InvestigationGroups { get; set; }
    public DbSet<AssignedInvestigationGroup> AssignedInvestigationsGroup { get; set; }

    #region Immunisations

    public DbSet<Shot> Shots { get; set; }
    public DbSet<Batch> Batches { get; set; }
    public DbSet<ShotBatch> ShotBatches { get; set; }
    public DbSet<ProgramCourse> ProgramCourses { get; set; }
    public DbSet<CourseShot> CourseShots { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<ImmunisationProgram> ImmunisationPrograms { get; set; }

    #endregion

    #endregion

    #region User

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserClinic> UserClinics { get; set; }
    public DbSet<UserTask> UserTasks { get; set; }
    public DbSet<ChatMessage> ChatMessages { get; set; }
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
    public DbSet<ImmunisationSchedule> ImmunisationSchedules { get; set; }
    public DbSet<AdministerShot> AdministerShots { get; set; }
    public DbSet<Reaction> Reactions { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PatientInvestigation> PatientInvestigations { get; set; }
    public DbSet<InvestigationResult> InvestigationResults { get; set; }
    public DbSet<InvestigationAudit> InvestigationAudits { get; set; }
    public DbSet<ConsultationLetter> ConsultationLetters { get; set; }
    public DbSet<LetterReply> LetterReplies { get; set; }
    public DbSet<ScannedDocument> ScannedDocuments { get; set; }

    #endregion
}