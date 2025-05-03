namespace Services.Features.Settings.Dtos;

public class DrugSubstituteDto
{
    public Guid Id { get; set; }
    public string OriginalDrugName { get; set; }
    public int OriginalDrugId { get; set; }
    public int SubtituteDrugId { get; set; }
    public string SubtituteDrugName { get; set; }
    public bool Active { get; set; }
}