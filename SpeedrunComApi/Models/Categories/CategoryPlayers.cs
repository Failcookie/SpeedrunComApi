using Newtonsoft.Json;

namespace SpeedrunComApi.Models.Categories
{
    public record CategoryPlayers
    {
        [JsonProperty("type")]
        public CategoryPlayerType Type { get; init; }

        [JsonProperty("value")]
        public int Value { get; init; }
    }
}
