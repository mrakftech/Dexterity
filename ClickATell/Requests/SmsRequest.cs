namespace ClickATell.Requests;

public class SmsRequest
{
     public string Content { get; set; } = "";
    public List<string> To { get; set; } = [];
}