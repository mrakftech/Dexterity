using Domain.Contracts;

namespace Domain.Entities.UserAccounts;

public class Role : IBaseId, IBaseActionOn, IBaseActionBy
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public bool IsDeleted { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid? ModifiedBy { get; set; }
    public string Name { get; set; } = "";

    public bool IsDefualt { get; set; }
}