using Newtonsoft.Json;
using System.Diagnostics;

namespace SpeedrunComApi.Objects
{
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
	public class PagedApiResponse<T>
	{
		[JsonProperty]
		public int Status { get; private set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public T Data { get; private set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string Error { get; private set; }

		[JsonProperty]
		public bool IsSuccess => Status == 200;

		[JsonProperty]
		public bool HasError => Error != null;

		[JsonProperty]
		public ApiPagination Pagination { get; init; }

		public bool IsFinalPage { get => Pagination.Max != Pagination.Size; }

		private object DebuggerDisplay => IsSuccess ? Data : $"Error: {Status} | {Error}";
	}
}
