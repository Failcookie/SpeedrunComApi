using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpeedrunComApi.Models.General
{
    public record ApiLink
    {
        [JsonPropertyName("rel")]
        public string Rel { get; init; }

        [JsonPropertyName("uri")]
        public Uri Uri { get; init; }
    }
}
