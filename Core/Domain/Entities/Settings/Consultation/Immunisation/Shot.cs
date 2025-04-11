using System.ComponentModel.DataAnnotations;
using Domain.Contracts;

namespace Domain.Entities.Settings.Consultation.Immunisation
{
    public class Shot : IBaseId
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Dose { get; set; }
        [Required]
        public string Method { get; set; }
        public bool IsActive { get; set; }
        
        [Required]
        public string IntervalType { get; set; }
        public int IntervalMin { get; set; } = 60;
        public int IntervalMax { get; set; } = 120;
        public string Comment { get; set; }
        public string ClaimForm { get; set; }
    }
}
