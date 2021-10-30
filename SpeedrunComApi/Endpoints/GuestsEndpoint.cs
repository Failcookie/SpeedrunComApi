using Newtonsoft.Json;
using SpeedrunComApi.Interfaces;
using SpeedrunComApi.Models.Users;
using SpeedrunComApi.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunComApi.Endpoints
{
	public class GuestsEndpoint : EndpointBase
	{
		internal GuestsEndpoint(IRateLimitedRequester requester) : base(requester) { }

		private readonly string baseUrl = "v1/guests";

		public async Task<ApiResponse<Guest>> GetGuestByName(string name)
		{
			var response = await _requester.CreateGetRequestAsync(baseUrl + $"/{name}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiResponse<Guest>>(response);
		}
	}
}
