using Domain.Contracts;

namespace Domain.Entities.Settings.Templates;

public class SketchCategory : IBaseId
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ICollection<Sketch> Sketches { get; set; }
}