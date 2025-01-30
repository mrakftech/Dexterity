namespace Domain.Contracts;

public interface IErrorFlag
{
    public bool IsErroneousRecord { get; set; }
}