using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace omg.GraphTopologicalSorting.Models
{
    [Serializable]
    public class VisGraphModel
    {
        [JsonProperty("Nodes")]
        public List<NodeModel> Nodes { get; set; }

        [JsonProperty("Edges")]
        public List<EdgeModel> Edges { get; set; }
    }
}
