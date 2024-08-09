using Domain.Contracts;
using Domain.Entities.PatientManagement.Extra;

namespace Domain.Entities.PatientManagement
{
   public class PatientExtraDetail:IBaseId
    {
        public Guid Id { get; set; }
        public OtherDetail OtherDetails { get; set; }
        public MaritalDetail MaritalDetails { get; set; }

        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
