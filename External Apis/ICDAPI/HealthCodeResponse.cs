using System.Text.Json.Serialization;

namespace ICDAPI;

public class HealthCodeResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("stemId")]
    public string stemId { get; set; }

    [JsonPropertyName("isLeaf")]
    public bool isLeaf { get; set; }

    [JsonPropertyName("postcoordinationAvailability")]
    public int postcoordinationAvailability { get; set; }

    [JsonPropertyName("hasCodingNote")]
    public bool hasCodingNote { get; set; }

    [JsonPropertyName("hasMaternalChapterLink")]
    public bool hasMaternalChapterLink { get; set; }

    [JsonPropertyName("hasPerinatalChapterLink")]
    public bool hasPerinatalChapterLink { get; set; }

    [JsonPropertyName("propertiesTruncated")]
    public bool propertiesTruncated { get; set; }

    [JsonPropertyName("isResidualOther")]
    public bool isResidualOther { get; set; }

    [JsonPropertyName("isResidualUnspecified")]
    public bool isResidualUnspecified { get; set; }

    [JsonPropertyName("chapter")]
    public string chapter { get; set; }

    [JsonPropertyName("theCode")]
    public string TheCode { get; set; }

    [JsonPropertyName("score")]
    public double score { get; set; }

    [JsonPropertyName("titleIsASearchResult")]
    public bool titleIsASearchResult { get; set; }

    [JsonPropertyName("titleIsTopScore")]
    public bool titleIsTopScore { get; set; }

    [JsonPropertyName("entityType")]
    public int entityType { get; set; }

    [JsonPropertyName("important")]
    public bool important { get; set; }

    [JsonPropertyName("descendants")]
    public List<object> descendants { get; set; }
}