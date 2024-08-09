namespace Domain.Entities.PatientManagement
{
    public class DoctorVisitCard
    {
        public int Id { get; set; }
        public string DvNumber { get; set; }
        public string DvReviewDate { get; set; }
        public string DvReviewNumber { get; set; }
        public string DvDistanceCode { get; set; }

        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }

    }
}
