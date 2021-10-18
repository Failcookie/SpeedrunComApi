using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunComApi.Objects
{
    /// <summary>
    /// Options for dependency injection
    /// </summary>
    public class SpeedrunComApiOptions
    {
        /// <summary>
        /// Sliding expiration time for caching of the static data endpoint
        /// </summary>
        public TimeSpan SlidingExpirationTime { get; set; }

        /// <summary>
        /// Cache type for the API. By default caching is disabled.
        /// </summary>
        public CacheType CacheType { get; set; }

        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the rate limits.
        /// </summary>
        public IDictionary<TimeSpan, int> RateLimits { get; set; }


        public SpeedrunComApiOptions()
        {

        }
    }
}
