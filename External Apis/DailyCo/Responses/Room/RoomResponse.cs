using System.Text.Json.Serialization;

namespace DailyCo.Responses.Room;

public class RoomResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("api_created")]
    public bool ApiCreated { get; set; }

    [JsonPropertyName("privacy")]
    public string Privacy { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("config")]
    public Config Config { get; set; }
}
public class Config
{
}