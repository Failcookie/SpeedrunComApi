using Newtonsoft.Json;
using SpeedrunComApi.EnumOptions;
using SpeedrunComApi.Interfaces;
using SpeedrunComApi.Models.Categories;
using SpeedrunComApi.Models.Games;
using SpeedrunComApi.Objects;
using SpeedrunComApi.Utilities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SpeedrunComApi.Endpoints
{
    public class GamesEndpoint : EndpointBase
	{
		internal GamesEndpoint(IRateLimitedRequester requester) : base(requester) { }

		private readonly string baseUrl = "v1/games";

		#region List of Games
        public async Task<ApiResponse<List<Game>>> GetGamesAsync(int pageSize = 20, int page = 1, GameOrderBy orderBy = GameOrderBy.InternationalName, SortDirection sortDir = SortDirection.Asc)
		{
			var parameters = GetGamesListDefaultParameters(orderBy, sortDir, pageSize , page);

			var response = await _requester.CreateGetRequestAsync(baseUrl, parameters).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiResponse<List<Game>>>(response);
		}

		public async Task<ApiResponse<List<Game>>> GetGamesByNameAsync(string name, int pageSize = 20, int page = 1, GameOrderBy orderBy = GameOrderBy.Similarity, SortDirection sortDir = SortDirection.Asc, CancellationToken token = default)
		{
			var parameters = GetGamesListDefaultParameters(orderBy, sortDir, pageSize, page);
			parameters.Add($"name={name}");

			var response = await _requester.CreateGetRequestAsync(baseUrl, parameters).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiResponse<List<Game>>>(response);
		}

		public async Task<ApiResponse<List<Game>>> GetGamesByAbbreviationAsync(string abbreviation, int pageSize = 20, int page = 1, GameOrderBy orderBy = GameOrderBy.InternationalName, SortDirection sortDir = SortDirection.Asc, CancellationToken token = default)
		{
			var parameters = GetGamesListDefaultParameters(orderBy, sortDir, pageSize, page);
			parameters.Add($"abbreviation={abbreviation}");

			var response = await _requester.CreateGetRequestAsync(baseUrl, parameters).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiResponse<List<Game>>>(response);
		}

		public async Task<ApiResponse<List<Game>>> GetGamesByYearReleasedAsync(int year, int pageSize = 20, int page = 1, GameOrderBy orderBy = GameOrderBy.InternationalName, SortDirection sortDir = SortDirection.Asc, CancellationToken token = default)
		{
			var parameters = GetGamesListDefaultParameters(orderBy, sortDir, pageSize, page);
			parameters.Add($"released={year}");

			var response = await _requester.CreateGetRequestAsync(baseUrl, parameters).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiResponse<List<Game>>>(response);
		}

		/// <param name="pageSize">Max amount of 1000</param>
		public async Task<ApiResponse<List<GameBulk>>> GetGamesBulkAsync(int pageSize = 100, int page = 1, GameOrderBy orderBy = GameOrderBy.InternationalName, SortDirection sortDir = SortDirection.Asc, CancellationToken token = default)
		{
			if(pageSize > 1000)
            {
				throw new ArgumentOutOfRangeException("The max number must be lower than 1,000");
            }

			var parameters = GetGamesListDefaultParameters(orderBy, sortDir, pageSize, page);
			parameters.Add($"_bulk=yes");

			var response = await _requester.CreateGetRequestAsync(baseUrl, parameters).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiResponse<List<GameBulk>>>(response);
		}

		private List<string> GetGamesListDefaultParameters(GameOrderBy orderBy, SortDirection sortDir, int max, int page)
        {
			List<string> parameters = new List<string>();
			parameters.Add($"direction={sortDir.GetDescription()}");
			parameters.Add($"orderby={orderBy.GetDescription()}");
			parameters.Add($"max={max}");
			if (page > 1)
			{
				parameters.Add($"offset={max * (page - 1)}");
			}

			return parameters;
		}
		#endregion

		/// <param name="id">Game abbreviation or ID</param>
		public async Task<ApiResponse<Game>> GetGameAsync(string id, CancellationToken token = default)
		{
			var response = await _requester.CreateGetRequestAsync(baseUrl + $"/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiResponse<Game>>(response);
		}

		/// <param name="miscellaneous">If true, filter our misc categories.</param>
		public async Task<ApiResponse<List<Category>>> GetGameGategoriesAsync(string id, bool miscellaneous = false, CancellationToken token = default)
		{
			string parsedMisc = miscellaneous ? "yes" : "no";
			List<string> parameters = new List<string> { $"miscellaneous={parsedMisc}" };

			var response = await _requester.CreateGetRequestAsync(baseUrl + $"/{id}/categories", parameters).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiResponse<List<Category>>>(response);
		}
	}
}
