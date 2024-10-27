using System.ComponentModel.DataAnnotations;
using Domain.Contracts;

namespace Domain.Entities.Settings.Consultation.Immunisation;

public class ShotBatch : IBaseId
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public Batch Batch { get; set; }
    public Guid BatchId { get; set; }

    public Shot Shot { get; set; }
    public Guid ShotId { get; set; }
}