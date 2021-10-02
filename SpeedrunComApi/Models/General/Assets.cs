using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpeedrunComApi.Models.General
{
    public record Assets
    {
        [JsonPropertyName("logo")]
        public AssetDetails Logo { get; init; }

        [JsonPropertyName("cover-tiny")]
        public AssetDetails CoverTiny { get; init; }

        [JsonPropertyName("cover-small")]
        public AssetDetails CoverSmall { get; init; }

        [JsonPropertyName("cover-medium")]
        public AssetDetails CoverMedium { get; init; }

        [JsonPropertyName("cover-large")]
        public AssetDetails CoverLarge { get; init; }

        [JsonPropertyName("icon")]
        public AssetDetails Icon { get; init; }

        [JsonPropertyName("trophy-1st")]
        public AssetDetails TrophyFirstPlace { get; init; }

        [JsonPropertyName("trophy-2nd")]
        public AssetDetails TrophySecondPlace { get; init; }

        [JsonPropertyName("trophy-3rd")]
        public AssetDetails TrophyThirdPlace { get; init; }

        [JsonPropertyName("trophy-4th")]
        public AssetDetails TrophyFourthPlace { get; init; }

        [JsonPropertyName("background")]
        public AssetDetails Background { get; init; }

        [JsonPropertyName("foreground")]
        public AssetDetails Foreground { get; init; }
    }

    public record AssetDetails
    {
        [JsonPropertyName("uri")]
        public Uri Uri { get; init; }

        [JsonPropertyName("width")]
        public int Width { get; init; }

        [JsonPropertyName("height")]
        public int Height { get; init; }
    }
}
