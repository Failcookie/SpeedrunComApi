using Newtonsoft.Json;

namespace SpeedrunComApi.Models.Games
{
    public record GameBulkName
    {
        [JsonProperty("international")]
        public string International { get; init; }

        [JsonProperty("japanese")]
        public string Japanese { get; init; }
    }
}
