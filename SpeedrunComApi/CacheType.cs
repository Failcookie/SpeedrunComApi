using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunComApi
{
    public enum CacheType
    {
        /// <summary>
        /// No <see cref="SpeedrunComApi.Caching.ICache"/> implementation gets registered. Use this type when you want to inject your custom <see cref="SpeedrunComApi.Caching.ICache"/> implementation.
        /// </summary>
        None,
        /// <summary>
        /// Disable caching
        /// </summary>
        PassThrough,
        /// <summary>
        /// Use SpeedrumComApi's internal cache implementation for caching. (Not recommended)
        /// </summary>
        Internal,
        /// <summary>
        /// Use ASP.NET Core's in-memory cache implementation for caching.
        /// </summary>
        Memory,
        /// <summary>
        /// Use ASP.NET Core's distributed cache implementation for caching.
        /// </summary>
        Distributed,
        /// <summary>
        /// Use ASP.NET Core's in-memory cache as a primary caching location and distributed as a fallback.
        /// </summary>
        Hybrid,
    }
}
