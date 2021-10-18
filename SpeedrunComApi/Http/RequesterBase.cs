using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunComApi.Http
{
    public abstract class RequesterBase
    {
        private readonly HttpClient _httpClient;
        private static HashSet<HttpStatusCode> httpStatusCodeResponse = new HashSet<HttpStatusCode>(){
            HttpStatusCode.BadRequest, HttpStatusCode.Unauthorized,
            HttpStatusCode.Forbidden,  HttpStatusCode.NotFound,
            HttpStatusCode.MethodNotAllowed, HttpStatusCode.UnsupportedMediaType,
            HttpStatusCode.InternalServerError, HttpStatusCode.BadRequest,
            HttpStatusCode.ServiceUnavailable, HttpStatusCode.GatewayTimeout
        };

        public string ApiKey { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequesterBase"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <exception cref="ArgumentNullException">apiKey</exception>
        protected RequesterBase(string apiKey) : this()
        {
            ApiKey = apiKey;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequesterBase"/> class.
        /// </summary>
        protected RequesterBase()
        {
            var assemblyVersion = GetType().Assembly.GetName().Version;
            var versionString = assemblyVersion == null ? "unknown" : assemblyVersion.ToString(3);

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("SpeedrunComApi.NET", versionString));
        }

        #region Protected Methods

        /// <summary>
        /// Send a <see cref="HttpRequestMessage"/> asynchronously.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="SpeedrunComApiException">Thrown if an Http error occurs. Contains the Http error code and error message.</exception>
        protected async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                HandleRequestFailure(response); //Pass Response to get status code, Then Dispose Object.
            }
            return response;
        }

        protected HttpRequestMessage PrepareRequest(string host, string relativeUrl, List<string> queryParameters, HttpMethod httpMethod)
        {
            var url = queryParameters == null ?
                $"https://{host}{relativeUrl}" :
                $"https://{host}{relativeUrl}?{BuildArgumentsString(queryParameters)}";

            var requestMessage = new HttpRequestMessage(httpMethod, url);
            if (!string.IsNullOrEmpty(ApiKey))
            {
                requestMessage.Headers.Add("X-API-Key", ApiKey);
            }
            return requestMessage;
        }

        protected string BuildArgumentsString(List<string> arguments)
        {
            return arguments
                .Where(arg => !string.IsNullOrWhiteSpace(arg))
                .Aggregate(string.Empty, (current, arg) => current + ("&" + arg));
        }

        protected void HandleRequestFailure(HttpResponseMessage response)
        {
            try
            {
                if (response.StatusCode == (HttpStatusCode)429)
                {
                    var retryAfter = TimeSpan.Zero;
                    if (response.Headers.TryGetValues("Retry-After", out var retryAfterHeaderValues))
                    {
                        if (int.TryParse(retryAfterHeaderValues.FirstOrDefault(), out var seconds))
                        {
                            retryAfter = TimeSpan.FromSeconds(seconds);
                        }
                    }

                    string rateLimitType = null;
                    if (response.Headers.TryGetValues("X-Rate-Limit-Type", out var rateLimitTypeHeaderValues))
                    {
                        rateLimitType = rateLimitTypeHeaderValues.FirstOrDefault();
                    }
                    throw new SpeedrunComApiRateLimitException("429, Rate Limit Exceeded", response.StatusCode, retryAfter, rateLimitType);
                }
                else if (httpStatusCodeResponse.Contains(response.StatusCode))
                {
                    string message;
                    try // try get error message from response
                    {
                        var json = response.Content.ReadAsStringAsync().Result;
                        var obj = JObject.Parse(json);
                        message = obj["status"]["message"].ToObject<string>();
                    }
                    catch
                    {
                        message = response.StatusCode.ToString();
                    }
                    throw new SpeedrunComApiException(message, response.StatusCode);
                }
                else
                    throw new SpeedrunComApiException("Unexpeced failure", response.StatusCode);
            }
            finally
            {
                response.Dispose(); //Dispose Response On Error
            }
        }

        protected async Task<string> GetResponseContentAsync(HttpResponseMessage response)
        {
            using (response)
            using (var content = response.Content)
            {
                return await content.ReadAsStringAsync().ConfigureAwait(false);
            }
        }

        #endregion
    }
}
