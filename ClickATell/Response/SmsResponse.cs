using System.Text.Json.Serialization;

namespace ClickATell.Response;

public class SmsResponse
{
    [JsonPropertyName("apiMessageId")]
    public string ApiMessageId { get; set; }

    [JsonPropertyName("accepted")]
    public bool Accepted { get; set; }

    [JsonPropertyName("to")]
    public string To { get; set; }

    [JsonPropertyName("errorCode")]
    public object ErrorCode { get; set; }

    [JsonPropertyName("error")]
    public object Error { get; set; }

    [JsonPropertyName("errorDescription")]
    public object ErrorDescription { get; set; }
}


public class Root
{
    [JsonPropertyName("responseCode")]
    public int ResponseCode { get; set; }
    [JsonPropertyName("messages")]
    public List<SmsResponse> Messages { get; set; }
}