using SpeedrunComApi.Models.General;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpeedrunComApi.Models.Games
{
    public record Game
    {
        [JsonPropertyName("id")]
        public string ID { get; init; }

        [JsonPropertyName("names")]
        public GameName Names { get; init; }

        [JsonPropertyName("abbreviation")]
        public string Abbreviation { get; init; }

        [JsonPropertyName("weblink")]
        public Uri Weblink { get; init; }

        [JsonPropertyName("release-date")]
        public DateTime? ReleaseDate { get; init; }

        [JsonPropertyName("ruleset")]
        public GameRuleSet RuleSet { get; init; }

        [JsonPropertyName("romhack")]
        public bool Romhack { get; init; }

        [JsonPropertyName("gametypes")]
        public string[] GametypeIDs { get; init; } // TODO

        [JsonPropertyName("platforms")]
        public string[] PlatformIDs { get; init; }  // TODO

        [JsonPropertyName("regions")]
        public string[] Regions { get; init; }  // TODO

        [JsonPropertyName("genres")]
        public string[] GenreIDs { get; init; }  // TODO

        [JsonPropertyName("engines")]
        public string[] EngineIDs { get; init; }  // TODO

        [JsonPropertyName("developers")]
        public string[] DeveloperIDs { get; init; }  // TODO

        [JsonPropertyName("publishers")]
        public string[] PublisherIDs { get; init; }  // TODO

        [JsonPropertyName("moderators")]
        public Dictionary<string, string> Moderators { get; init; }  // TODO

        [JsonPropertyName("created")]
        public DateTimeOffset? Created { get; init; }

        [JsonPropertyName("assets")]
        public Assets Assets { get; init; }

        [JsonPropertyName("links")]
        public ReadOnlyCollection<ApiLink> Links { get; init; }
    }
}
