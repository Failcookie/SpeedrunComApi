using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using SpeedrunComApi.Caching;
using SpeedrunComApi.Http;
using SpeedrunComApi.Interfaces;
using SpeedrunComApi.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunComApi
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddSpeedrunComApi(this IServiceCollection serviceCollection)
        {
            if (serviceCollection == null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            var apiOptions = new SpeedrunComApiOptions();

            AddCache(serviceCollection, apiOptions);

            var rateLimitedRequester = new RateLimitedRequester(apiOptions.ApiKey, apiOptions.RateLimits);

            serviceCollection.AddSingleton<ISpeedrunComApiClient>(serviceProvider => new SpeedrunComApiClient(rateLimitedRequester));

            return serviceCollection;
        }

        public static IServiceCollection AddSpeedrunComApi(this IServiceCollection serviceCollection, Action<SpeedrunComApiOptions> options)
        {
            if(serviceCollection == null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            var apiOptions = new SpeedrunComApiOptions();
            options(apiOptions);

            AddCache(serviceCollection, apiOptions);

            var rateLimitedRequester = new RateLimitedRequester(apiOptions.ApiKey, apiOptions.RateLimits);

            serviceCollection.AddSingleton<ISpeedrunComApiClient>(serviceProvider => new SpeedrunComApiClient(rateLimitedRequester));

            return serviceCollection;
        }

        private static void AddCache(IServiceCollection serviceCollection, SpeedrunComApiOptions options)
        {
            switch (options.CacheType)
            {
                case CacheType.None:
                    break;
                case CacheType.PassThrough:
                    serviceCollection.AddSingleton<ICache, PassThroughCache>();
                    break;
                case CacheType.Internal:
                    serviceCollection.AddSingleton<ICache, Cache>();
                    break;
                case CacheType.Memory:
                    serviceCollection.AddSingleton<ICache, Caching.MemoryCache>();
                    break;
                case CacheType.Hybrid:
                    serviceCollection.AddSingleton<ICache, HybridCache>(
                    serviceProvider => new HybridCache(
                        serviceProvider.GetRequiredService<IMemoryCache>(),
                        serviceProvider.GetRequiredService<IDistributedCache>(),
                        options.SlidingExpirationTime));
                    break;
            }
        }
    }
}
