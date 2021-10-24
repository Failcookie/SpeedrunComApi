using Newtonsoft.Json;
using SpeedrunComApi.Interfaces;
using SpeedrunComApi.Models.Users;
using SpeedrunComApi.Objects;
using System.Collections.Generic;
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
	}
}
