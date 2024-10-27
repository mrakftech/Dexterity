using System.ComponentModel.DataAnnotations;
using Domain.Contracts;

namespace Domain.Entities.Settings.Consultation.Immunisation;

public class CourseShot : IBaseId
{
    [Key] public Guid Id { get; set; } = Guid.NewGuid();

    public Course Course { get; set; }
    public Guid CourseId { get; set; }
    public Shot Shot { get; set; }
    public Guid ShotId { get; set; }
    public int Order { get; set; }
}