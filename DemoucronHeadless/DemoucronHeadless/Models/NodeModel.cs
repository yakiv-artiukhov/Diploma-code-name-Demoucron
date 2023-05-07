using Newtonsoft.Json;

namespace DemoucronHeadless.Models;

[Serializable]
public class NodeModel
{
    [JsonProperty("Id")]
    public int Id { get; set; }

    [JsonProperty("Label")]
    public string Label { get; set; }

    [JsonProperty("Level")]
    public int Level { get; set; }
}
