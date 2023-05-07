using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DemoucronHeadless.Models;

[Serializable]
public class VisGraphModel
{
    [JsonProperty("Nodes")]
    public List<NodeModel> Nodes { get; set; }

    [JsonProperty("Edges")]
    public List<EdgeModel> Edges { get; set; }
}
