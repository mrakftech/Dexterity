using Domain.Entities.Settings.Immunisation;

namespace Services.Features.Settings.Dtos.Immunisations
{
    public class ShotDto
    {
        public Shot Shot { get; set; }
        public List<BatchDetail> BatchDetails { get; set; }
    }
}
