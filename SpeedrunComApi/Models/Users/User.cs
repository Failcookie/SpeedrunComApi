using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SpeedrunComApi.Models.Users
{
    public record User
    {
        [JsonPropertyName("id")]
        public string ID { get; init; }

        [JsonPropertyName("names")]
        public UserName Names { get; init; }

        [JsonPropertyName("weblink")]
        public string Weblink { get; init; }

        [JsonPropertyName("role")]
        public UserRole Role { get; init; }

        [JsonPropertyName("signup")]
        public DateTimeOffset? Signup { get; init; }
    }
}
