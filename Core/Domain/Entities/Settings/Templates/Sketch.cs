using System.ComponentModel.DataAnnotations;
using Domain.Contracts;

namespace Domain.Entities.Settings.Templates;

public class Sketch : IBaseId
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "required")] public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    [Required(ErrorMessage = "required")] public string Image { get; set; }

    public SketchCategory SketchCategory { get; set; }
    public Guid SketchCategoryId { get; set; }
}