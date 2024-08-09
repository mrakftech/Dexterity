using Domain.Contracts;

namespace Domain.Entities.PatientManagement
{
    public class PatientOccupation : IBaseId
    {
        public Guid Id { get; set ; } = Guid.NewGuid();
        public string Type { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
