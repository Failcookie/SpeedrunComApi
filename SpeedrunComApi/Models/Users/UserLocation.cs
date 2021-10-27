using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunComApi.Models.Users
{
    public record UserLocation
    {
        [JsonProperty("country")]
        public UserCountry County { get; init; }

        [JsonProperty("region")]
        public UserRegion Region { get; init; }
    }

    public record UserCountry
    {
        [JsonProperty("code")]
        public string Code { get; init; }

        [JsonProperty("names")]
        public LocalName Names { get; init; }
    }

    public record UserRegion
    {
        [JsonProperty("code")]
        public string Code { get; init; }

        [JsonProperty("names")]
        public LocalName Names { get; init; }
    }
}
