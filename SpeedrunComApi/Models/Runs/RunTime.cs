using Newtonsoft.Json;
using SpeedrunComApi.Utilities;
using System;

namespace SpeedrunComApi.Models.Runs
{
    public record RunTime
    {
        /// <summary>
        /// Time that is relevant to the leaderboard.
        /// </summary>
        [JsonConverter(typeof(TimeSpanConverterFromSeconds))]
        [JsonProperty("primary_t")]
        public TimeSpan? PrimaryTimeSpan { get; init; }

        /// <summary>
        /// Real-world time of the run.
        /// </summary>
        [JsonProperty("realtime_t")]
        [JsonConverter(typeof(TimeSpanConverterFromSeconds))]
        public TimeSpan? RealTimeSpan { get; init; }

        /// <summary>
        /// Real-world time of the run, excluding the loading times. Not all games have a distinction between realtime and realtime w/o loads.
        /// </summary>
        [JsonProperty("realtime_noloads_t")]
        [JsonConverter(typeof(TimeSpanConverterFromSeconds))]
        public TimeSpan? RealTimeWithoutLoadsSpan { get; init; }

        /// <summary>
        ///  Time as measured by the game itself.
        /// </summary>
        [JsonProperty("ingame_t")]
        [JsonConverter(typeof(TimeSpanConverterFromSeconds))]
        public TimeSpan? GameTimeSpan { get; init; }
    }
}
