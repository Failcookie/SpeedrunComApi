using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpeedrunComApi.Models.Runs
{
    public record RunVideo
    {
        [JsonProperty("text")]
        public string Text { get; init; }

        [JsonProperty("links")]
        public List<RunVideoLink> Links { get; init; }
    }

    public record RunVideoLink
    {
        [JsonProperty("uri")]
        public Uri Uri { get; init; }
    }
}
