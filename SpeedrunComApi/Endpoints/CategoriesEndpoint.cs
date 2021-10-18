using Newtonsoft.Json;
using SpeedrunComApi.Interfaces;
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
		internal CategoriesEndpoint(IRateLimitedRequester requester) : base(requester) { }

		private readonly string baseUrl = "v1/categories";

		public async Task<ApiResponse<Category>> GetCategoryByIdAsync(string id)
		{
			if(string.IsNullOrEmpty(id))
            {
				throw new ArgumentNullException("id");
			}

			var response = await _requester.CreateGetRequestAsync(baseUrl + $"/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiResponse<Category>>(response);
		}
	}
}
