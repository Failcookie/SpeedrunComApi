using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedrunComApi.Endpoints
{
	public abstract class EndpointBase
	{
		internal readonly IRestClient _client;

		internal EndpointBase(IRestClient client)
		{
			_client = client;
		}
	}
}
