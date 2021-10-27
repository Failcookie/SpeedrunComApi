using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunComApi.Models.General
{
    public record UriObject
    {
        [JsonProperty("uri")]
        public Uri Uri { get; init; }
    }
}
