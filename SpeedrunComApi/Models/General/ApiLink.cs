using System;
using Newtonsoft.Json;

namespace SpeedrunComApi.Models.General
{
    public record ApiLink
    {
        [JsonProperty("rel")]
        public string Rel { get; init; }

        [JsonProperty("uri")]
        public Uri Uri { get; init; }
    }
}
