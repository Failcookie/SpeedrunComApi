using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using SpeedrunComApi.Models.General;

namespace SpeedrunComApi.Models.Users
{
    public record User
    {
        [JsonProperty("id")]
        public string ID { get; init; }

        [JsonProperty("names")]
        public LocalName Names { get; init; }

        [JsonProperty("weblink")]
        public string Weblink { get; init; }

        [JsonProperty("role")]
        public UserRole Role { get; init; }

        [JsonProperty("signup")]
        public DateTimeOffset? Signup { get; init; }

        [JsonProperty("location")]
        public UserLocation Location { get; init; }

        [JsonProperty("twitch")]
        public UriObject Twitch { get; init; }

        [JsonProperty("hitbox")]
        public UriObject Hitbox { get; init; }

        [JsonProperty("youtube")]
        public UriObject YouTube { get; init; }

        [JsonProperty("twitter")]
        public UriObject Twitter { get; init; }

        [JsonProperty("speedrunslive")]
        public UriObject SpeedRunsLive { get; init; }

        [JsonProperty("links")]
        public ReadOnlyCollection<ApiLink> Links { get; init; }
    }
}
