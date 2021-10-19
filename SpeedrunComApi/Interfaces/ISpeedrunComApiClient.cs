using SpeedrunComApi.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunComApi.Interfaces
{
    public interface ISpeedrunComApiClient
    {
        UsersEndpoint Users { get; }
        CategoriesEndpoint Categories { get; }
        GamesEndpoint Games { get; }
        RunsEndpoint Runs { get; }
    }
}
