using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Settings.Immunisation
{
    public class Shot
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Dose { get; set; }
        public string Method { get; set; }
        public bool IsActive { get; set; }
        public string IntervalType { get; set; }
        public int IntervalMin { get; set; } = 60;
        public int IntervalMax { get; set; } = 120;
        public string Comment { get; set; }
        public string ClaimForm { get; set; }

    }
}
