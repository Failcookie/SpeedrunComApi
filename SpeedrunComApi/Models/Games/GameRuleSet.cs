using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpeedrunComApi.Models.Games
{
    public record GameRuleSet
    {
        [JsonPropertyName("show-milliseconds")]
        public bool ShowMilliseconds { get; init; }

        [JsonPropertyName("require-verification")]
        public bool RequireVerification { get; init; }

        [JsonPropertyName("require-video")]
        public bool RequireVideo { get; init; }

        [JsonPropertyName("default-time")]
        public GameTimingMethod DefaultTime { get; init; }

        [JsonPropertyName("emulators-allowed")]
        public bool EmulatorsAllowed { get; init; }

        [JsonProperty("run-times", ItemConverterType = typeof(StringEnumConverter))]
        public ReadOnlyCollection<GameTimingMethod> RunTimes { get; init; }
    }
}
