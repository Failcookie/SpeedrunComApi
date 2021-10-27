using Newtonsoft.Json;
using SpeedrunComApi.Models.Categories;
using SpeedrunComApi.Models.Games;
using SpeedrunComApi.Models.Runs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunComApi.Models.Users
{
    public record UserPersonalBest
    {
        [JsonProperty("place")]
        public int Place { get; init; }

        [JsonProperty("run")]
        public Run Run { get; init; }

        [JsonProperty("game")]
        public Game Game { get; init; }

        [JsonProperty("category")]
        public Category Category { get; init; }
    }
}
