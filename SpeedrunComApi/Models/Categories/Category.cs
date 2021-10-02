using System.Text.Json.Serialization;

namespace SpeedrunComApi.Models.Categories
{
    public record Category
    {
        [JsonPropertyName("id")]
        public string ID { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("weblink")]
        public string Weblink { get; init; }

        [JsonPropertyName("type")]
        public string Type { get; init; }

        [JsonPropertyName("rules")]
        public string Rules { get; init; }

        [JsonPropertyName("miscellaneous")]
        public bool Miscellaneous { get; init; }

        [JsonPropertyName("players")]
        public CategoryPlayers Players { get; init; }
    }
}
