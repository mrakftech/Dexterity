using System.ComponentModel.DataAnnotations;
using Domain.Contracts;

namespace Domain.Entities.Consultation;

public class Reaction : IBaseId
{
    [Key] public Guid Id { get; set; }
    public DateTime ReactionDate { get; set; } = DateTime.Now;
    [Required(ErrorMessage = "Required")] public string ReactionType { get; set; }
    [Required(ErrorMessage = "Required")] public string Side { get; set; }
    public string Comment { get; set; }
    public AdministerShot AdministerShot { get; set; }
    public Guid AdministerShotId { get; set; }
}