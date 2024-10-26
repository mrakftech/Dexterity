    namespace Domain.Entities.Settings.Consultation.Immunisation;

    public class AssignedBatchToShot
    {
        public int Id { get; set; }
        public BatchDetail BatchDetail { get; set; }
        public int BatchDetailId { get; set; }
        
        public Shot Shot { get; set; }
        public int ShotId { get; set; }
    }