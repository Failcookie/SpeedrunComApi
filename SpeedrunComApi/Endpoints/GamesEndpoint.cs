using RestSharp;
using SpeedrunComApi.EnumOptions;
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
        public async Task<ApiResponse<List<Game>>> GetGamesAsync(GameOrderBy orderBy = GameOrderBy.InternationalName, SortDirection sortDir = SortDirection.Desc, CancellationToken token = default)
		{
			var request = new RestRequest(baseUrl, Method.GET);
			addGamesListDefaultParameters(request, orderBy, sortDir);

			var response = await _client.ExecuteAsync<ApiResponse<List<Game>>>(request, token).ConfigureAwait(false);

			return response.Data;
		}

		public async Task<ApiResponse<List<Game>>> GetGamesByNameAsync(string name, GameOrderBy orderBy = GameOrderBy.Similarity, SortDirection sortDir = SortDirection.Desc, CancellationToken token = default)
		{
			var request = new RestRequest(baseUrl, Method.GET);
			request.AddParameter("name", name);
			addGamesListDefaultParameters(request, orderBy, sortDir);

			var response = await _client.ExecuteAsync<ApiResponse<List<Game>>>(request, token).ConfigureAwait(false);

			return response.Data;
		}

		public async Task<ApiResponse<List<Game>>> GetGamesByAbbreviationAsync(string abbreviation, GameOrderBy orderBy = GameOrderBy.InternationalName, SortDirection sortDir = SortDirection.Desc, CancellationToken token = default)
		{
			var request = new RestRequest(baseUrl, Method.GET);
			request.AddParameter("abbreviation", abbreviation);
			addGamesListDefaultParameters(request, orderBy, sortDir);

			var response = await _client.ExecuteAsync<ApiResponse<List<Game>>>(request, token).ConfigureAwait(false);

			return response.Data;
		}

		public async Task<ApiResponse<List<Game>>> GetGamesByYearReleasedAsync(int year, GameOrderBy orderBy = GameOrderBy.InternationalName, SortDirection sortDir = SortDirection.Desc, CancellationToken token = default)
		{
			var request = new RestRequest(baseUrl, Method.GET);
			request.AddParameter("released", year);
			addGamesListDefaultParameters(request, orderBy, sortDir);

			var response = await _client.ExecuteAsync<ApiResponse<List<Game>>>(request, token).ConfigureAwait(false);

			return response.Data;
		}

		public async Task<ApiResponse<List<GameBulk>>> GetGamesBulkAsync(GameOrderBy orderBy = GameOrderBy.InternationalName, SortDirection sortDir = SortDirection.Desc, int max = 100, CancellationToken token = default)
		{
			var request = new RestRequest(baseUrl, Method.GET);
			request.AddParameter("_bulk", "yes");
			request.AddParameter("max", max);
			addGamesListDefaultParameters(request, orderBy, sortDir);

			var response = await _client.ExecuteAsync<ApiResponse<List<GameBulk>>>(request, token).ConfigureAwait(false);

			return response.Data;
		}

		private void addGamesListDefaultParameters(RestRequest request, GameOrderBy orderBy, SortDirection sortDir)
        {
			request.AddParameter("direction", sortDir.GetDescription());
			request.AddParameter("orderby", orderBy.GetDescription());
		}
		#endregion

		/// <param name="id">Game abbreviation or ID</param>
		public async Task<ApiResponse<Game>> GetGame(string id, CancellationToken token = default)
		{
			var request = new RestRequest(baseUrl + $"/{id}", Method.GET);
			var response = await _client.ExecuteAsync<ApiResponse<Game>>(request, token).ConfigureAwait(false);

			return response.Data;
		}

		/// <param name="miscellaneous">If true, filter our misc categories.</param>
		public async Task<ApiResponse<Game>> GetGameGategories(string id, bool miscellaneous = true, CancellationToken token = default)
		{
			string parsedMisc = miscellaneous ? "yes" : "no";

			var request = new RestRequest(baseUrl + $"/{id}/categories", Method.GET);
			request.AddParameter("miscellaneous", parsedMisc);
			var response = await _client.ExecuteAsync<ApiResponse<Game>>(request, token).ConfigureAwait(false);

			return response.Data;
		}
	}
}
