using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpeedrunComApi.Models.Games
{
    public record GameName
    {
        [JsonPropertyName("international")]
        public string International { get; init; }

        [JsonPropertyName("japanese")]
        public string Japanese { get; init; }

        [JsonPropertyName("twitch")]
        public string Twitch { get; init; }
    }
}
