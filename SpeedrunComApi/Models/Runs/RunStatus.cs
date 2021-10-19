using System;
using Newtonsoft.Json;

namespace SpeedrunComApi.Models.Runs
{
    public record RunStatus
    {
        [JsonProperty("status")]
        public string Status { get; init; }

        [JsonProperty("examiner")]
        public string ExaminerId { get; init; }

        /// <summary>
        /// Only contains data if the status is Rejected
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; init; }

        /// <summary>
        /// Only contains data if the status is Verified and has been verified after the "Old Days"
        /// </summary>
        [JsonProperty("verify-date")]
        public DateTimeOffset? VerifyDate { get; init; }
    }
}
