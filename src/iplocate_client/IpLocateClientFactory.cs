using System;
using System.Net.Http;

namespace IpLocate
{
	public static class IpLocateClientFactory
	{
		private const string DEFAULT_BASE_URL = "https://iplocate.io/api";
		private const int DEFAULT_TIMEOUT_MS = 30000;

		private const string HEADER_ACCEPT = "Accept";
		private const string HEADER_USER_AGENT = "User-Agent";
		private const string HEADER_API_KEY = "apikey";
		private const string CONTENT_TYPE_JSON = "application/json";
		private const string DEFAULT_USER_AGENT = "IPLocateClient-OkHttp/1.0";

		public static IpLocateClient Client(string apiKey)
		{
			return Client(apiKey, DEFAULT_BASE_URL, DEFAULT_TIMEOUT_MS, DEFAULT_USER_AGENT);
		}

		public static IpLocateClient Client(string apiKey, string baseUrl)
		{
			return Client(apiKey, baseUrl, DEFAULT_TIMEOUT_MS, DEFAULT_USER_AGENT);
		}

		public static IpLocateClient Client(string apiKey, string baseUrl, int timeoutMs, string userAgent)
		{
			if(string.IsNullOrWhiteSpace(apiKey)) throw new ArgumentException("Api key cannot be null or empty",nameof(apiKey));
			if(string.IsNullOrWhiteSpace(baseUrl)) throw new ArgumentException("Base URL cannot be null or empty",nameof(baseUrl));
			if(timeoutMs < 0) throw new ArgumentOutOfRangeException("Timeout must be a positive value",nameof(timeoutMs));


			if (!Uri.TryCreate(baseUrl, UriKind.RelativeOrAbsolute, out Uri baseUri))
				throw new ArgumentException("Invalid base URL format: {baseUrl}", nameof(baseUrl));

			var httpClient = new HttpClient
			{
				BaseAddress = baseUri,
				Timeout = TimeSpan.FromMilliseconds(timeoutMs),
				DefaultRequestHeaders =
				{
					{ HEADER_ACCEPT, CONTENT_TYPE_JSON },
					{ HEADER_USER_AGENT, userAgent },
					{ HEADER_API_KEY, apiKey},
				}
			};
			return new IpLocateClient(httpClient);
		}
	}
}
