using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpeedrunComApi.Models.Games
{
    public record GameBulk
    {
        [JsonPropertyName("id")]
        public string ID { get; init; }

        [JsonPropertyName("names")]
        public GameBulkName Names { get; init; }

        [JsonPropertyName("abbreviation")]
        public string Abbreviation { get; init; }

        [JsonPropertyName("weblink")]
        public Uri Weblink { get; init; }
    }
}
