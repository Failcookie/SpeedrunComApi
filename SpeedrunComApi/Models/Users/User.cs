using System;
using Newtonsoft.Json;

namespace SpeedrunComApi.Models.Users
{
    public record User
    {
        [JsonProperty("id")]
        public string ID { get; init; }

        [JsonProperty("names")]
        public UserName Names { get; init; }

        [JsonProperty("weblink")]
        public string Weblink { get; init; }

        [JsonProperty("role")]
        public UserRole Role { get; init; }

        [JsonProperty("signup")]
        public DateTimeOffset? Signup { get; init; }
    }
}
