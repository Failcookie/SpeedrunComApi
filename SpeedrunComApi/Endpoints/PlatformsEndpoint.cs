using Newtonsoft.Json;
using SpeedrunComApi.EnumOptions;
using SpeedrunComApi.Interfaces;
using SpeedrunComApi.Models.Platforms;
using SpeedrunComApi.Objects;
using SpeedrunComApi.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpeedrunComApi.Endpoints
{
	public class PlatformsEndpoint : EndpointBase
	{
		internal PlatformsEndpoint(IRateLimitedRequester requester) : base(requester) { }

		private readonly string baseUrl = "v1/platforms";

		public async Task<PagedApiResponse<List<Platform>>> GetAllPlatforms(int pageSize = 20, int page = 1, PlatformOrderBy orderBy = PlatformOrderBy.Name, SortDirection sortDir = SortDirection.Asc)
		{
			List<string> parameters = new List<string>();
			parameters.Add($"orderby={orderBy.GetDescription()}");
			parameters.Add($"direction={sortDir.GetDescription()}");
			parameters.Add($"max={pageSize}");
			if (page > 1)
			{
				parameters.Add($"offset={pageSize * (page - 1)}");
			}

			var response = await _requester.CreateGetRequestAsync(baseUrl, parameters).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<PagedApiResponse<List<Platform>>>(response);
		}

		public async Task<ApiResponse<Platform>> GetPlatformById(string id)
		{
			var response = await _requester.CreateGetRequestAsync(baseUrl + $"/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiResponse<Platform>>(response);
		}
	}
}
