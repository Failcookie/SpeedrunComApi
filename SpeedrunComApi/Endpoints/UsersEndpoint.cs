using RestSharp;
using SpeedrunComApi.Models.Users;
using SpeedrunComApi.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeedrunComApi.Endpoints
{
    public class UsersEndpoint : EndpointBase
    {
        internal UsersEndpoint(IRestClient client) : base(client) { }

		public async Task<ApiResponse<List<User>>> GetUsersAsync(CancellationToken token = default)
		{
			var request = new RestRequest("v1/users", Method.GET);
			var response = await _client.ExecuteAsync<ApiResponse<List<User>>>(request, token).ConfigureAwait(false);

			return response.Data;
		}
	}
}
