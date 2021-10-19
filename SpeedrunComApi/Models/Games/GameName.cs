using Newtonsoft.Json;

namespace SpeedrunComApi.Models.Games
{
    public record GameName
    {
        [JsonProperty("international")]
        public string International { get; init; }

        [JsonProperty("japanese")]
        public string Japanese { get; init; }

        [JsonProperty("twitch")]
        public string Twitch { get; init; }
    }
}
