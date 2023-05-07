using Newtonsoft.Json;

namespace omg.TopologicalSorting.Models
{
    [Serializable]
    public class NodeModel
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Label")]
        public string Label { get; set; }

        [JsonProperty("Level")]
        public string Level { get; set; }
    }
}
