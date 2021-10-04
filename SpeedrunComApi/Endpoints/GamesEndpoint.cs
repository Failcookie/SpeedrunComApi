using RestSharp;
using SpeedrunComApi.EnumOptions;
using SpeedrunComApi.Models.Categories;
using SpeedrunComApi.Models.Games;
using SpeedrunComApi.Objects;
using SpeedrunComApi.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeedrunComApi.Endpoints
{
	public class GamesEndpoint : EndpointBase
	{
		internal GamesEndpoint(IRestClient client) : base(client) { }

		private readonly string baseUrl = "v1/games";

		#region List of Games
        public async Task<ApiResponse<List<Game>>> GetGamesAsync(int pageSize = 20, int page = 1, GameOrderBy orderBy = GameOrderBy.InternationalName, SortDirection sortDir = SortDirection.Asc, CancellationToken token = default)
		{
			var request = new RestRequest(baseUrl, Method.GET);
			addGamesListDefaultParameters(request, orderBy, sortDir, pageSize , page);

			var response = await _client.ExecuteAsync<ApiResponse<List<Game>>>(request, token).ConfigureAwait(false);

			return response.Data;
		}

		public async Task<ApiResponse<List<Game>>> GetGamesByNameAsync(string name, int pageSize = 20, int page = 1, GameOrderBy orderBy = GameOrderBy.Similarity, SortDirection sortDir = SortDirection.Asc, CancellationToken token = default)
		{
			var request = new RestRequest(baseUrl, Method.GET);
			request.AddParameter("name", name);
			addGamesListDefaultParameters(request, orderBy, sortDir, pageSize, page);

			var response = await _client.ExecuteAsync<ApiResponse<List<Game>>>(request, token).ConfigureAwait(false);

			return response.Data;
		}

		public async Task<ApiResponse<List<Game>>> GetGamesByAbbreviationAsync(string abbreviation, int pageSize = 20, int page = 1, GameOrderBy orderBy = GameOrderBy.InternationalName, SortDirection sortDir = SortDirection.Asc, CancellationToken token = default)
		{
			var request = new RestRequest(baseUrl, Method.GET);
			request.AddParameter("abbreviation", abbreviation);
			addGamesListDefaultParameters(request, orderBy, sortDir, pageSize, page);

			var response = await _client.ExecuteAsync<ApiResponse<List<Game>>>(request, token).ConfigureAwait(false);

			return response.Data;
		}

		public async Task<ApiResponse<List<Game>>> GetGamesByYearReleasedAsync(int year, int pageSize = 20, int page = 1, GameOrderBy orderBy = GameOrderBy.InternationalName, SortDirection sortDir = SortDirection.Asc, CancellationToken token = default)
		{
			var request = new RestRequest(baseUrl, Method.GET);
			request.AddParameter("released", year);
			addGamesListDefaultParameters(request, orderBy, sortDir, pageSize, page);

			var response = await _client.ExecuteAsync<ApiResponse<List<Game>>>(request, token).ConfigureAwait(false);

			return response.Data;
		}

		/// <param name="pageSize">Max amount of 1000</param>
		public async Task<ApiResponse<List<GameBulk>>> GetGamesBulkAsync(int pageSize = 100, int page = 1, GameOrderBy orderBy = GameOrderBy.InternationalName, SortDirection sortDir = SortDirection.Asc, CancellationToken token = default)
		{
			if(pageSize > 1000)
            {
				throw new ArgumentOutOfRangeException("The max number must be lower than 1,000");
            }

			var request = new RestRequest(baseUrl, Method.GET);
			request.AddParameter("_bulk", "yes");
			addGamesListDefaultParameters(request, orderBy, sortDir, pageSize, page);

			var response = await _client.ExecuteAsync<ApiResponse<List<GameBulk>>>(request, token).ConfigureAwait(false);

			return response.Data;
		}

		private void addGamesListDefaultParameters(RestRequest request, GameOrderBy orderBy, SortDirection sortDir, int max, int page)
        {
			request.AddParameter("direction", sortDir.GetDescription());
			request.AddParameter("orderby", orderBy.GetDescription());
			request.AddParameter("max", max);
			if (page > 1)
			{
				request.AddParameter("offset", max * (page - 1));
			}
		}
		#endregion

		/// <param name="id">Game abbreviation or ID</param>
		public async Task<ApiResponse<Game>> GetGameAsync(string id, CancellationToken token = default)
		{
			var request = new RestRequest(baseUrl + $"/{id}", Method.GET);
			var response = await _client.ExecuteAsync<ApiResponse<Game>>(request, token).ConfigureAwait(false);

			return response.Data;
		}

		/// <param name="miscellaneous">If true, filter our misc categories.</param>
		public async Task<ApiResponse<List<Category>>> GetGameGategoriesAsync(string id, bool miscellaneous = false, CancellationToken token = default)
		{
			string parsedMisc = miscellaneous ? "yes" : "no";

			var request = new RestRequest(baseUrl + $"/{id}/categories", Method.GET);
			request.AddParameter("miscellaneous", parsedMisc);
			var response = await _client.ExecuteAsync<ApiResponse<List<Category>>>(request, token).ConfigureAwait(false);

			return response.Data;
		}
	}
}
