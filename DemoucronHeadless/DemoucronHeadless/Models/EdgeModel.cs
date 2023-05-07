using Newtonsoft.Json;

namespace DemoucronHeadless.Models;

[Serializable]
public class EdgeModel
{
    [JsonProperty("Id")]
    public string Id { get; set; }

    [JsonProperty("Label")]
    public string Label { get; set; }

    [JsonProperty("From")]
    public int From { get; set; }

    [JsonProperty("To")]
    public int To { get; set; }

    [JsonProperty("Arrows")]
    public string Arrows { get; set; }
}
