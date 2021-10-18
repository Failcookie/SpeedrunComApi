using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedrunComApi
{
	internal class JsonNetSerializer : IRestSerializer
	{
		private static readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
		{
			ContractResolver = new DefaultContractResolver
			{
				NamingStrategy = new CamelCaseNamingStrategy(false, false)
			}
		};

		public string Serialize(object obj)
		{
			return JsonConvert.SerializeObject(obj, _serializerSettings);
		}

#pragma warning disable CS0618 // Type or member is obsolete
        public string Serialize(Parameter parameter)
#pragma warning restore CS0618 // Type or member is obsolete
        {
			return JsonConvert.SerializeObject(parameter.Value, _serializerSettings);
		}

		public T Deserialize<T>(IRestResponse response)
		{
			return JsonConvert.DeserializeObject<T>(response.Content, _serializerSettings);
		}

		public string[] SupportedContentTypes { get; } =
		{
			"application/json",
			"application/json; charset=utf-8"
		};

		public string ContentType { get; set; } = "application/json; charset=utf-8";

		public DataFormat DataFormat => DataFormat.Json;
	}
}
