using Domain.Entities.PatientManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.PatientManagement.BasicDetails;
using Domain.Entities.PatientManagement.Extra;
using Newtonsoft.Json;

namespace Database.Configurations
{
    public class PatientExtraDetailConfiguration : IEntityTypeConfiguration<PatientExtraDetail>
    {
        public void Configure(EntityTypeBuilder<PatientExtraDetail> builder)
        {
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
        }
    }
}
