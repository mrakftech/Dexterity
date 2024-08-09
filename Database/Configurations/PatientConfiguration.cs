using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Domain.Entities.PatientManagement;
using Domain.Entities.PatientManagement.BasicDetails;

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
