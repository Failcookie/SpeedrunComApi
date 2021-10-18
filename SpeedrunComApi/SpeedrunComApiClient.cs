using RestSharp;
using SpeedrunComApi.Endpoints;
using SpeedrunComApi.Interfaces;
using System;

namespace SpeedrunComApi
{
    public class SpeedrunComApiClient : ISpeedrunComApiClient
    {
        public UsersEndpoint Users { get; }
        public CategoriesEndpoint Categories { get; }
        public GamesEndpoint Games { get; }

        /// <summary>
        /// Dependency injection constructor
        /// </summary>
        /// <param name="rateLimitedRequester">Rate limited requester for all endpoints.</param>
        public SpeedrunComApiClient(IRateLimitedRequester rateLimitedRequester, int? timeout = null)
        {
            var assemblyVersion = GetType().Assembly.GetName().Version;
            var versionString = assemblyVersion == null ? "unknown" : assemblyVersion.ToString(3);

            var client = new RestClient("https://www.speedrun.com/api/")
            {
                UserAgent = $"SpeedrunComApi.NET/{versionString}",
                Timeout = (int)(timeout ?? TimeSpan.FromSeconds(60).TotalMilliseconds)
            }.UseSerializer<JsonNetSerializer>();

            Users = new UsersEndpoint(client);
            Categories = new CategoriesEndpoint(client);
            Games = new GamesEndpoint(client);
        }
    }
}
