
namespace Domain.Entities.PatientManagement
{
    public class PatientOccupation 
    {
        public int Id { get; set ; } 
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
