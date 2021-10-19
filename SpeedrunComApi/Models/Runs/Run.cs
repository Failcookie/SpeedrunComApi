using SpeedrunComApi.Models.General;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpeedrunComApi.Models.Runs
{
    public record Run
    {
        [JsonProperty("id")]
        public string ID { get; init; }

        [JsonProperty("weblink")]
        public Uri Weblink { get; init; }

        [JsonProperty("game")]
        public string GameId { get; init; }

        [JsonProperty("level")]
        public string LevelId { get; init; }

        [JsonProperty("category")]
        public string CategoryId { get; init; }

        [JsonProperty("comment")]
        public string Comment { get; init; }

        /// <summary>
        /// Even though this is plural, Speedrun.com will only return one video. Several links may be returned.
        /// </summary>
        [JsonProperty("videos")]
        public RunVideo Videos { get; init; }

        [JsonProperty("status")]
        public RunStatus RunStatus { get; init; }

        [JsonProperty("players")]
        public List<RunPlayer> Players { get; init; }

        /// <summary>
        /// When the run happened
        /// </summary>
        [JsonProperty("date")]
        public DateTime? Date { get; init; }

        /// <summary>
        /// When the run was submitted
        /// </summary>
        [JsonProperty("submitted")]
        public DateTime? Submitted { get; init; }

        [JsonProperty("times")]
        public RunTime Times { get; init; }

        [JsonProperty("system")]
        public RunSystem System { get; init; }

        [JsonProperty("splits")]
        public ApiLink Splits { get; init; }

        [JsonProperty("links")]
        public List<ApiLink> Links { get; init; }
    }
}
