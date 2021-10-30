using Newtonsoft.Json;
using SpeedrunComApi.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunComApi.Objects
{
    public record ApiPagination
    {
        [JsonProperty("offset")]
        public int Offset { get; init; }

        [JsonProperty("max")]
        public int Max { get; init; }

        [JsonProperty("size")]
        public int Size { get; init; }

        [JsonProperty("links")]
        public IReadOnlyCollection<ApiLink> Links { get; init; }
    }
}
