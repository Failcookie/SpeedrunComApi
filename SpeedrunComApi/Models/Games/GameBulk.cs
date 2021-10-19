using System;
using Newtonsoft.Json;

namespace SpeedrunComApi.Models.Games
{
    public record GameBulk
    {
        [JsonProperty("id")]
        public string ID { get; init; }

        [JsonProperty("names")]
        public GameBulkName Names { get; init; }

        [JsonProperty("abbreviation")]
        public string Abbreviation { get; init; }

        [JsonProperty("weblink")]
        public Uri Weblink { get; init; }
    }
}
