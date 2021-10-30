using Newtonsoft.Json;
using SpeedrunComApi.Models.General;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunComApi.Models.Users
{
    public record Guest
    {
        [JsonProperty("name")]
        public string Name { get; init; }

        [JsonProperty("links")]
        public ReadOnlyCollection<ApiLink> Links { get; init; }
    }
}
