using Newtonsoft.Json;
using SpeedrunComApi.Interfaces;
using SpeedrunComApi.Models.Users;
using SpeedrunComApi.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedrunComApi.Endpoints
{
    public class UsersEndpoint : EndpointBase
    {
        internal UsersEndpoint(IRateLimitedRequester requester) : base(requester) { }

		private readonly string baseUrl = "v1/users";

		public async Task<ApiResponse<List<User>>> GetUsersAsync()
		{
			var response = await _requester.CreateGetRequestAsync(baseUrl).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiResponse<List<User>>>(response);
		}

		public async Task<ApiResponse<User>> GetUserbyId(string id)
		{
			var response = await _requester.CreateGetRequestAsync(baseUrl + $"/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiResponse<User>>(response);
		}

		public async Task<ApiResponse<User>> GetUserByUsername(string name)
		{
			var response = await _requester.CreateGetRequestAsync(baseUrl + $"/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiResponse<User>>(response);
		}

		/// <summary>
		/// This will retrieve a list of runs, representing the Personal Bests of the given user. This will not include obsolete runs.
		/// </summary>
		/// <param name="id">The user ID or username is allowed.</param>
		/// <param name="top">When given, only PBs with a place equal or better than this value. Example - a 1 will return all World Records of a given user.</param>
		/// <param name="series">When given, restricts the result to games and romhacks in that series; can be either a series ID or abbreviation.</param>
		/// <param name="game">When given, restricts the result to that game; can be either a game ID or abbreviation.</param>
		/// <param name="embeds">A list of embeds for this API hit. Can either be a game and/or category.</param>
		/// <returns></returns>
		public async Task<ApiResponse<List<UserPersonalBest>>> GetPersonalBestsByUserId(string id, int? top = null, string series = null, string game = null, List<string> embeds = null)
		{
			List<string> parameters = new List<string>();
			if (embeds != null)
			{
				embeds.ForEach(m => parameters.Add("embed=" + string.Join(",", embeds)));
			}

			if (top.HasValue)
			{
				parameters.Add($"top={top}");
			}

			if (!string.IsNullOrEmpty(series))
			{
				parameters.Add($"series={series}");
			}

			if (!string.IsNullOrEmpty(game))
			{
				parameters.Add($"game={game}");
			}
			var response = await _requester.CreateGetRequestAsync(baseUrl + $"/{id}/personal-bests", parameters).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiResponse<List<UserPersonalBest>>>(response);
		}
	}
}
