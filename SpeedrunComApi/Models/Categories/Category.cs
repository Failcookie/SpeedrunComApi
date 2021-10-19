using Newtonsoft.Json;

namespace SpeedrunComApi.Models.Categories
{
    public record Category
    {
        [JsonProperty("id")]
        public string ID { get; init; }

        [JsonProperty("name")]
        public string Name { get; init; }

        [JsonProperty("weblink")]
        public string Weblink { get; init; }

        [JsonProperty("type")]
        public string Type { get; init; }

        [JsonProperty("rules")]
        public string Rules { get; init; }

        [JsonProperty("miscellaneous")]
        public bool Miscellaneous { get; init; }

        [JsonProperty("players")]
        public CategoryPlayers Players { get; init; }
    }
}
