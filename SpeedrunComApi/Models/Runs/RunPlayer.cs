using System;
using Newtonsoft.Json;

namespace SpeedrunComApi.Models.Runs
{
    public record RunPlayer
    {
        [JsonProperty("rel")]
        public RunPlayerRelationOptions Relation { get; init; }

        [JsonProperty("id")]
        public string Id { get; init; }

        [JsonProperty("name")]
        public string Name { get; init; }

        [JsonProperty("uri")]
        public Uri Uri { get; init; }

        public bool IsUser { get => Relation == RunPlayerRelationOptions.User; }
    }
}
