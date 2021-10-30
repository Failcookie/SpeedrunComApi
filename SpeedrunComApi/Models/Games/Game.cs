using SpeedrunComApi.Models.General;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace SpeedrunComApi.Models.Games
{
    public record Game
    {
        [JsonProperty("id")]
        public string ID { get; init; }

        [JsonProperty("names")]
        public GameName Names { get; init; }

        [JsonProperty("abbreviation")]
        public string Abbreviation { get; init; }

        [JsonProperty("weblink")]
        public Uri Weblink { get; init; }

        [JsonProperty("release-date")]
        public DateTime? ReleaseDate { get; init; }

        [JsonProperty("ruleset")]
        public GameRuleSet RuleSet { get; init; }

        [JsonProperty("romhack")]
        public bool Romhack { get; init; }

        [JsonProperty("gametypes")]
        public string[] GametypeIDs { get; init; }

        [JsonProperty("platforms")]
        public string[] PlatformIDs { get; init; }

        [JsonProperty("regions")]
        public string[] Regions { get; init; }

        [JsonProperty("genres")]
        public string[] GenreIDs { get; init; }

        [JsonProperty("engines")]
        public string[] EngineIDs { get; init; }

        [JsonProperty("developers")]
        public string[] DeveloperIDs { get; init; }

        [JsonProperty("publishers")]
        public string[] PublisherIDs { get; init; }

        [JsonProperty("moderators")]
        public Dictionary<string, string> Moderators { get; init; }

        [JsonProperty("created")]
        public DateTimeOffset? Created { get; init; }

        [JsonProperty("assets")]
        public Assets Assets { get; init; }

        [JsonProperty("links")]
        public ReadOnlyCollection<ApiLink> Links { get; init; }
    }
}
