using SpeedrunComApi.Interfaces;

namespace SpeedrunComApi.Endpoints
{
    public abstract class EndpointBase
	{
		internal readonly IRateLimitedRequester _requester;

		internal EndpointBase(IRateLimitedRequester requester)
		{
			_requester = requester;
		}
	}
}
