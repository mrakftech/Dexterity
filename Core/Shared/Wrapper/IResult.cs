namespace Shared.Wrapper;

public interface IResult
{
    List<string> Messages { get; set; }

    bool Succeeded { get; set; }
    public string GetFirstMessage();

}

public interface IResult<out T> : IResult
{
    T Data { get; }
}