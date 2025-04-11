namespace Domain.Entities.PatientManagement.Details
{
    public class MedicalCardDetail
    {
        public string GmsStatus { get; set; } = "No";
        public string GmsDoctor { get; set; }
        public string GmsPatientNumber { get; set; }
        public DateTime GmsReviewDate { get; set; } = DateTime.Now;
        public string GmsDoctorNumber { get; set; }
        public string GmsDistanceCode { get; set; }
    }
}
