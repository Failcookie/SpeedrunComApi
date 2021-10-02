using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpeedrunComApi.Models.Categories
{
    public record CategoryPlayers
    {
        [JsonPropertyName("type")]
        public CategoryPlayerType Type { get; init; }

        [JsonPropertyName("value")]
        public int Value { get; init; }
    }
}
