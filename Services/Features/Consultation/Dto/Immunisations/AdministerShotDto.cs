using System.ComponentModel.DataAnnotations;
using Domain.Entities.Settings.Consultation.Immunisation;
using Services.State;
using Shared.Attributes;

namespace Services.Features.Consultation.Dto.Immunisations;

public class AdministerShotDto
{
    public DateTime DueDate { get; set; }
    public DateTime GivenDate { get; set; } = DateTime.UtcNow;
    [Required(ErrorMessage = "Required")] public string Side { get; set; }
    [NotEmpty(ErrorMessage = "Required")] public Guid HcpId { get; set; } = ApplicationState.CurrentUser.UserId;
    public string ShotName { get; set; }
    public string ShotDose { get; set; }
    public string ShotMethod { get; set; }
    public string ShotComment { get; set; }

    public Guid BatchId { get; set; }
    public string BatchNumber { get; set; }
    public DateTime Expiry { get; set; }
    public string TradeName { get; set; }
    public string ManfactureName { get; set; }
    public int Remaining { get; set; }
    public bool IsBacthExpired { get; set; }
    public bool IsGiven { get; set; }
    public bool IsDue { get; set; }
    public bool IsCancelled { get; set; }
    public bool IsFirstShot { get; set; }

    public List<Batch> Batches { get; set; }
}