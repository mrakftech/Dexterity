using Domain.Contracts;
using Domain.Entities.UserAccounts;

namespace Domain.Entities.Common;

public class FlagRecord : IBaseId
{
    public Guid Id { get; set; }
    public string Reason { get; set; }
    public string ModuleName { get; set; }
    public string Description { get; set; }
    public Guid RecordId { get; set; }
    public Guid CurrentPatientId { get; set; }
    public Guid? ReassignedToPatientId { get; set; }
    public string Status { get; set; } = nameof(FlagRecordStatus.Flagged);
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedDate { get; set; }
    
    
    public Guid FlaggedById { get; set; } 
    public User FlaggedBy { get; set; }
    
    public Guid? ResolvedById { get; set; } 
    public User ResolvedBy { get; set; }

}

public enum FlagRecordStatus
{
    Flagged,
    Resolved,
}