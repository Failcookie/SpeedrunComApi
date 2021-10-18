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

		public async Task<ApiResponse<List<User>>> GetUsersAsync()
		{
			var response = await _requester.CreateGetRequestAsync("v1/users").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiResponse<List<User>>>(response);
		}
	}
}
