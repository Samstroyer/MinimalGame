using System.Text.Json.Serialization;

public class Position
{
    [JsonPropertyName("x")]
    public int x { get; set; }
    [JsonPropertyName("y")]
    public int y { get; set; }
}
