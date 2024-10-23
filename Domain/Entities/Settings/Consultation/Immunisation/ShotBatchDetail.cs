    namespace Domain.Entities.Settings.Consultation.Immunisation;

    public class ShotBatchDetail
    {
        public int Id { get; set; }
        public BatchDetail BatchDetail { get; set; }
        public int BatchDetailId { get; set; }
        public Shot Shot { get; set; }
        public int ShotId { get; set; }
    }