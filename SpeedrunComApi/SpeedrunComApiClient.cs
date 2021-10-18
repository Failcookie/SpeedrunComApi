using SpeedrunComApi.Endpoints;
using SpeedrunComApi.Interfaces;

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
        public SpeedrunComApiClient(IRateLimitedRequester rateLimitedRequester)
        {
            Users = new UsersEndpoint(rateLimitedRequester);
            Categories = new CategoriesEndpoint(rateLimitedRequester);
            Games = new GamesEndpoint(rateLimitedRequester);
        }
    }
}
