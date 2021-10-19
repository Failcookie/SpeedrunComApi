using System;
using Newtonsoft.Json;

namespace SpeedrunComApi.Models.Runs
{
    public record RunPlayer
    {
        [JsonProperty("rel")]
        public string Rel { get; init; }

        [JsonProperty("id")]
        public string Id { get; init; }

        [JsonProperty("uri")]
        public Uri Uri { get; init; }
    }
}
