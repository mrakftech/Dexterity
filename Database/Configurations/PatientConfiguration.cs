using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Domain.Entities.PatientManagement;
using Domain.Entities.PatientManagement.Details;

namespace Database.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable(name: "Patients", "PatientManagement");


            builder.HasOne(d => d.Clinic)
                .WithMany(p => p.Patients)
                .HasForeignKey(d => d.ClinicId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(d => d.Hcp)
                .WithMany(p => p.Patients)
                .HasForeignKey(d => d.HcpId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(e => e.Address)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<PatientAddress>(v)
                );


            builder
                .Property(e => e.MedicalCardDetails)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<MedicalCardDetail>(v)
                );
            
            builder
                .Property(e => e.OtherDetails)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<OtherDetail>(v)
                );

            builder
                .Property(e => e.MaritalDetails)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<MaritalDetail>(v)
                );
            
            builder
                .Property(e => e.DrugPaymentSchemeDetails)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<DrugPaymentSchemeDetail>(v)
                );

            builder
                .Property(e => e.PrivateHealthInsuranceDetails)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<PrivateHealthInsuranceDetail>(v)
                );
        }
    }
}