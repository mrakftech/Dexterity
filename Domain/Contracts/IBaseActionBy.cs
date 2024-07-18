namespace Domain.Contracts;

public interface IBaseActionBy
{
    public Guid CreatedBy { get; set; }
    public Guid? ModifiedBy { get; set; }
}