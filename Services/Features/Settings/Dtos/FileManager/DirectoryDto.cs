namespace Services.Features.Settings.Dtos.FileManager;

public class DirectoryDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
}