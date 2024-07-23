using Domain.Entities.Messaging;
using Domain.Entities.PatientManagement;
using Domain.Entities.Settings;
using Domain.Entities.UserAccounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<SmsTemplate> SmsTemplates { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserClinic> UserClinics { get; set; }
    public DbSet<UserTask> UserTasks { get; set; }
    public DbSet<PermissionClaim> PermissionClaims { get; set; }

    public DbSet<Clinic> Clinics { get; set; }


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

        builder.Entity<User>(entity => { entity.ToTable(name: "Users", "UserManagement"); });
        builder.Entity<UserClinic>(entity => { entity.ToTable(name: "UsersClinics", "UserManagement"); });
        builder.Entity<Role>(entity => { entity.ToTable(name: "Roles", "UserManagement"); });
        builder.Entity<PermissionClaim>(entity => { entity.ToTable(name: "Permissions", "UserManagement"); });
        
        
        builder.Entity<SmsTemplate>(entity => { entity.ToTable(name: "SmsTemplates", "Messaging"); });
        builder.Entity<UserTask>(entity => { entity.ToTable(name: "UserTasks", "Messaging"); });
        
        
        
        builder.Entity<Clinic>(entity => { entity.ToTable(name: "Clinics", "Setting"); });
        builder.Entity<Patient>(entity => { entity.ToTable(name: "Patients", "PatientManagement"); });
    }
}