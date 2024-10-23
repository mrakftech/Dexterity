using Domain.Entities.Appointments;
using Domain.Entities.Consultation;
using Domain.Entities.Messaging;
using Domain.Entities.PatientManagement.Alert;
using Domain.Entities.PatientManagement.Allergies;
using Domain.Entities.PatientManagement.Billing;
using Domain.Entities.PatientManagement.Extra;
using Domain.Entities.PatientManagement.Family;
using Domain.Entities.PatientManagement.Group;
using Domain.Entities.PatientManagement.Options;
using Domain.Entities.Settings.Account;
using Domain.Entities.Settings.Clinic;
using Domain.Entities.Settings.Consultation;
using Domain.Entities.Settings.Consultation.Immunisation;
using Domain.Entities.Settings.Drugs;
using Domain.Entities.Settings.Templates;
using Domain.Entities.UserAccounts;
using Microsoft.EntityFrameworkCore;

namespace Database.Configurations;

public static class SchemaConfigurations
{
    public static void Configure(ModelBuilder builder)
    {


        builder.Entity<User>(entity => { entity.ToTable(name: "Users", "Identity"); });
        builder.Entity<Role>(entity => { entity.ToTable(name: "Roles", "Identity"); });
        builder.Entity<PermissionClaim>(entity => { entity.ToTable(name: "Permissions", "Identity"); });
        builder.Entity<UserClinic>(entity => { entity.ToTable(name: "UserClinics", "Identity"); });


        builder.Entity<UserTask>(entity => { entity.ToTable(name: "UserTasks", "Messaging"); });
        builder.Entity<ChatMessage>(entity => { entity.ToTable(name: "ChatMessages", "Messaging"); });


        builder.Entity<EmailTemplate>(entity => { entity.ToTable(name: "EmailTemplates", "Setting"); });
        builder.Entity<SmsTemplate>(entity => { entity.ToTable(name: "SmsTemplates", "Setting"); });
        builder.Entity<Clinic>(entity => { entity.ToTable(name: "Clinic", "Setting"); });
        builder.Entity<ClinicSite>(entity => { entity.ToTable(name: "ClinicSites", "Setting"); });
        builder.Entity<AppointmentType>(entity => { entity.ToTable(name: "AppointmentTypes", "Setting"); });
        builder.Entity<AppointmentCancellationReason>(entity => { entity.ToTable(name: "AppointmentCancellationReasons", "Setting"); });
        builder.Entity<AccountType>(entity => { entity.ToTable(name: "AccountTypes", "Setting"); });
        builder.Entity<PomrGroup>(entity => { entity.ToTable(name: "PomrGroups", "Setting"); });
        builder.Entity<HealthCode>(entity => { entity.ToTable(name: "HeathCodes", "Setting"); });
        builder.Entity<NoteTemplate>(entity => { entity.ToTable(name: "NoteTemplates", "Setting"); });
        builder.Entity<Drug>(entity => { entity.ToTable(name: "Drugs", "Setting"); });
        builder.Entity<Shot>(entity => { entity.ToTable(name: "Shots", "Setting"); });
        builder.Entity<BatchDetail>(entity => { entity.ToTable(name: "BatchDetails", "Setting"); });
        builder.Entity<ShotBatchDetail>(entity => { entity.ToTable(name: "ShotBatchDetails", "Setting"); });
        builder.Entity<Course>(entity => { entity.ToTable(name: "Courses", "Setting"); });
        builder.Entity<ShotCourse>(entity => { entity.ToTable(name: "ShotCourses", "Setting"); });
        builder.Entity<ImmunisationSetup>(entity => { entity.ToTable(name: "ImmunisationSetups", "Setting"); });
        builder.Entity<CourseSchedule>(entity => { entity.ToTable(name: "CourseSchedules", "Setting"); });

        
        
        
        
        
        
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


        builder.Entity<ConsultationDetail>(entity => { entity.ToTable(name: "Details", "Consultation"); });
        builder.Entity<BaselineDetail>(entity => { entity.ToTable(name: "BaselineDetails", "Consultation"); });
        builder.Entity<Reminder>(entity => { entity.ToTable(name: "Reminders", "Consultation"); });
        builder.Entity<ConsultationNote>(entity => { entity.ToTable(name: "Notes", "Consultation"); });
     
    }
}