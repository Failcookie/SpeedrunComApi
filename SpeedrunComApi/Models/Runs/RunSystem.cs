using Newtonsoft.Json;

namespace SpeedrunComApi.Models.Runs
{
    public record RunSystem
    {
        [JsonProperty("platform")]
        public string PlatformId { get; init; }

        [JsonProperty("emulated")]
        public bool Wmulated { get; init; }

        [JsonProperty("region")]
        public string RegionId { get; init; }
    }
}
