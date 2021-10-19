using System;
using Newtonsoft.Json;

namespace SpeedrunComApi.Models.General
{
    public record Assets
    {
        [JsonProperty("logo")]
        public AssetDetails Logo { get; init; }

        [JsonProperty("cover-tiny")]
        public AssetDetails CoverTiny { get; init; }

        [JsonProperty("cover-small")]
        public AssetDetails CoverSmall { get; init; }

        [JsonProperty("cover-medium")]
        public AssetDetails CoverMedium { get; init; }

        [JsonProperty("cover-large")]
        public AssetDetails CoverLarge { get; init; }

        [JsonProperty("icon")]
        public AssetDetails Icon { get; init; }

        [JsonProperty("trophy-1st")]
        public AssetDetails TrophyFirstPlace { get; init; }

        [JsonProperty("trophy-2nd")]
        public AssetDetails TrophySecondPlace { get; init; }

        [JsonProperty("trophy-3rd")]
        public AssetDetails TrophyThirdPlace { get; init; }

        [JsonProperty("trophy-4th")]
        public AssetDetails TrophyFourthPlace { get; init; }

        [JsonProperty("background")]
        public AssetDetails Background { get; init; }

        [JsonProperty("foreground")]
        public AssetDetails Foreground { get; init; }
    }

    public record AssetDetails
    {
        [JsonProperty("uri")]
        public Uri Uri { get; init; }

        [JsonProperty("width")]
        public int Width { get; init; }

        [JsonProperty("height")]
        public int Height { get; init; }
    }
}
