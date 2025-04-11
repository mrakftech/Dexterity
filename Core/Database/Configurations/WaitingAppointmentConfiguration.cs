using Domain.Entities.WaitingRoom;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Configurations;

public class WaitingAppointmentConfiguration: IEntityTypeConfiguration<WaitingAppointment>
{
    public void Configure(EntityTypeBuilder<WaitingAppointment> builder)
    {
        builder.ToTable(name: "WaitingAppointments", "Scheduler");
        builder.HasOne(d => d.Patient)
            .WithMany(p => p.WaitingAppointments)
            .HasForeignKey(d => d.PatientId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(d => d.Clinic)
            .WithMany(p => p.WaitingAppointments)
            .HasForeignKey(d => d.ClinicId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}