using System.ComponentModel.DataAnnotations;

namespace Services.Features.Admin.Dtos.FlagRecords;

public class FlagRecordDto
{
    [Required] public string Reason { get; set; }
    public Guid RecordId { get; set; }
    public string ModuleName { get; set; }
    [Required] public string Description { get; set; }
}