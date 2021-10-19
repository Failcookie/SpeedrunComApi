using Newtonsoft.Json;

namespace SpeedrunComApi.Models.Users
{
    public record UserName
    {
        [JsonProperty("international")]
        public string International { get; init; }

        [JsonProperty("japanese")]
        public string Japanese { get; init; }
    }
}
