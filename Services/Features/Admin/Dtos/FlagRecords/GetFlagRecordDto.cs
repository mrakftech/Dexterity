namespace Services.Features.Admin.Dtos.FlagRecords;

public class GetFlagRecordDto
{
    public Guid Id { get; set; }
    public string Reason { get; set; }
    public string ModuleName { get; set; }
    public string Description { get; set; }
    public Guid RecordId { get; set; }
    public string ReassignedToPatientId { get; set; }
    public string Status { get; set; } 
    public DateTime CreatedDate { get; set; } 
    public DateTime? ModifiedDate { get; set; }
    public string FlaggedBy { get; set; } 
    public string ResolvedBy { get; set; } 
}