using Newtonsoft.Json;
using SpeedrunComApi.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunComApi.Models.Platforms
{
    public record Platform
    {
        [JsonProperty("id")]
        public string ID { get; init; }

        [JsonProperty("name")]
        public string Name { get; init; }

        /// <summary>
        /// The year it was released.
        /// </summary>
        [JsonProperty("released")]
        public int Released { get; init; }

        [JsonProperty("links")]
        public IReadOnlyCollection<ApiLink> Links { get; init; }
    }
}
