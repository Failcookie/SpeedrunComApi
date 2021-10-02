using RestSharp;
using SpeedrunComApi.Endpoints;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedrunComApi
{
    public class SpeedrunComApiClient
    {
        public UsersEndpoint Users { get; }
        public CategoriesEndpoint Categories { get; }
        public GamesEndpoint Games { get; }

        public SpeedrunComApiClient(int? timeout = null)
        {
            var assemblyVersion = GetType().Assembly.GetName().Version;
            var versionString = assemblyVersion == null ? "unknown" : assemblyVersion.ToString(3);

            var client = new RestClient("https://www.speedrun.com/api/")
            {
                UserAgent = $"SpeedrunComApi.NET/{versionString}",
                Timeout = (int)(timeout ?? TimeSpan.FromSeconds(30).TotalMilliseconds)
            }.UseSerializer<JsonNetSerializer>();

            Users = new UsersEndpoint(client);
            Categories = new CategoriesEndpoint(client);
            Games = new GamesEndpoint(client);
        }
    }
}
