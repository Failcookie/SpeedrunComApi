using SpeedrunComApi.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunComApi.Http
{
    /// <summary>
    /// A requester with a rate limiter
    /// </summary>
    /// <seealso cref="RiotSharp.Http.RequesterBase" />
    /// <seealso cref="RiotSharp.Http.Interfaces.IRateLimitedRequester" />
    public class RateLimitedRequester : RequesterBase, IRateLimitedRequester
    {
        public readonly IDictionary<TimeSpan, int> RateLimits;

        private readonly bool _throwOnDelay;
        private readonly string _host = "https://www.speedrun.com/api";
        private readonly ConcurrentDictionary<string, RateLimiter> _rateLimiters = new ConcurrentDictionary<string, RateLimiter>();

        /// <inheritdoc />
        public RateLimitedRequester(string apiKey, IDictionary<TimeSpan, int> rateLimits, bool throwOnDelay = false) : base(apiKey)
        {
            RateLimits = rateLimits;
            _throwOnDelay = throwOnDelay;
        }

        #region Public Methods

        /// <inheritdoc />
        public Task<string> CreateGetRequestAsync(string relativeUrl, List<string> queryParameters = null)
        {
            var request = PrepareRequest(_host, relativeUrl, queryParameters, HttpMethod.Get);

            return GetRateLimitedResponseContentAsync(request);
        }

        /// <inheritdoc />
        public Task<string> CreatePostRequestAsync(string relativeUrl, string body, List<string> queryParameters = null)
        {
            var request = PrepareRequest(_host, relativeUrl, queryParameters, HttpMethod.Post);
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");

            return GetRateLimitedResponseContentAsync(request);
        }

        /// <inheritdoc />
        public async Task<bool> CreatePutRequestAsync(string relativeUrl, string body, List<string> queryParameters = null)
        {
            var request = PrepareRequest(_host, relativeUrl, queryParameters, HttpMethod.Put);
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");

            await GetRateLimiter().HandleRateLimitAsync().ConfigureAwait(false);
            try
            {
                var response = await SendAsync(request).ConfigureAwait(false);
                response.Dispose();
                return true;

            }
            catch (SpeedrunComApiException)
            {
                return false;
            }
        }

        #endregion

        /// <summary>
        /// Returns the RateLimiter, creating it if needed.
        /// </summary>
        /// <returns></returns>
        private RateLimiter GetRateLimiter()
        {
            return _rateLimiters.GetOrAdd("main", _ => new RateLimiter(RateLimits, _throwOnDelay));
        }

        /// <summary>
        /// Sends a configured <see cref="HttpRequestMessage"/> possibly Rate-Limited
        /// </summary>
        /// <param name="request">Pre-Configured <see cref="HttpRequestMessage"/></param>
        private async Task<string> GetRateLimitedResponseContentAsync(HttpRequestMessage request)
        {
            await GetRateLimiter().HandleRateLimitAsync().ConfigureAwait(false);

            using (var response = await SendAsync(request).ConfigureAwait(false))
            {
                return await GetResponseContentAsync(response).ConfigureAwait(false);
            }
        }
    }
}
