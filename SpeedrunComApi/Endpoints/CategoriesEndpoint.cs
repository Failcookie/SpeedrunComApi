using RestSharp;
using SpeedrunComApi.Models.Categories;
using SpeedrunComApi.Objects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SpeedrunComApi.Endpoints
{
    public class CategoriesEndpoint : EndpointBase
	{
		internal CategoriesEndpoint(IRestClient client) : base(client) { }

		public async Task<ApiResponse<List<Category>>> GetCategoryByIdAsync(string id, CancellationToken token = default)
		{
			if(string.IsNullOrEmpty(id))
            {
				throw new ArgumentNullException("id");

			}
			var request = new RestRequest("v1/categories/{id}", Method.GET);
			var response = await _client.ExecuteAsync<ApiResponse<List<Category>>>(request, token).ConfigureAwait(false);

			return response.Data;
		}
	}
}
