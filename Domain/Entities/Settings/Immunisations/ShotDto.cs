using Domain.Entities.Settings.Consultation.Immunisation;

namespace Domain.Entities.Settings.Immunisations
{
    public class ShotDto
    {
        public Shot Shot { get; set; }
        public List<BatchDetail> BatchDetails { get; set; }
    }
}
