using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace omg.TopologicalSorting.Models
{
    [Serializable]
    public class EdgeModel
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Label")]
        public string Label { get; set; }

        [JsonProperty("From")]
        public string From { get; set; }

        [JsonProperty("To")]
        public string To { get; set; }

        [JsonProperty("Arrows")]
        public string Arrows { get; set; }
    }
}
