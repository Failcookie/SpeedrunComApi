using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.ObjectModel;

namespace SpeedrunComApi.Models.Games
{
    public record GameRuleSet
    {
        [JsonProperty("show-milliseconds")]
        public bool ShowMilliseconds { get; init; }

        [JsonProperty("require-verification")]
        public bool RequireVerification { get; init; }

        [JsonProperty("require-video")]
        public bool RequireVideo { get; init; }

        [JsonProperty("default-time")]
        public GameTimingMethod DefaultTime { get; init; }

        [JsonProperty("emulators-allowed")]
        public bool EmulatorsAllowed { get; init; }

        [JsonProperty("run-times", ItemConverterType = typeof(StringEnumConverter))]
        public ReadOnlyCollection<GameTimingMethod> RunTimes { get; init; }
    }
}
