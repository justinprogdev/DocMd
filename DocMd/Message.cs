using System.Text.Json.Serialization;

internal class Message
{
    [JsonPropertyName("role")]
    public string Role { get; internal set; }
    [JsonPropertyName("content")]
    public string Content { get; internal set; }
}