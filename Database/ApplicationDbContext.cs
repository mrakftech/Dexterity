using Domain.Entities.Messaging;
using Domain.Entities.PatientManagement;
using Domain.Entities.UserAccounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shared.Constants.Application;
using Shared.Constants.Role;
using Shared.Helper;

namespace Database;

public class ApplicationDbContext : DbContext
{
    //public DbSet<Appointment> Appointment { get; set; }
    // public DbSet<NewTask> NewTask { get; set; }
    // public DbSet<Drug> Drug { get; set; }
    // public DbSet<Wax> Wax { get; set; }
    //public DbSet<Notes> Notes { get; set; }
    // public DbSet<NoteTemplate> NoteTemplate { get; set; }
    // public DbSet<Template> Template { get; set; }
    // public DbSet<Message> Message { get; set; }
    //public DbSet<Consultation> Consultation { get; set; }
    public DbSet<SmsTemplate> SmsTemplates { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<PermissionClaim> PermissionClaims { get; set; }
    
    
    
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options
    )
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder();

        IConfiguration configuration =
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

        optionsBuilder.UseSqlServer(configuration["ConnectionStrings:AppConnection"] ?? string.Empty);

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
    }
}