namespace iplocate_client;

public static class IpLocateClientFactory
{
	private const string DEFAULT_BASE_URL = "https://iplocate.io/api";
	private const int DEFAULT_TIMEOUT_MS = 30000;

	private const string HEADER_ACCEPT = "Accept";
	private const string HEADER_USER_AGENT = "User-Agent";
	private const string HEADER_API_KEY = "apikey";
	private const string CONTENT_TYPE_JSON = "application/json";
	private const string DEFAULT_USER_AGENT = "IPLocateClient-OkHttp/1.0";

	public static async ValueTask<IpLocateClient> ClientAsync(string apiKey)
	{
		return await ClientAsync(apiKey, DEFAULT_BASE_URL, DEFAULT_TIMEOUT_MS, DEFAULT_USER_AGENT);
	}

	public static async ValueTask<IpLocateClient> ClientAsync(string apiKey, string baseUrl)
	{
		return await ClientAsync(apiKey, baseUrl, DEFAULT_TIMEOUT_MS, DEFAULT_USER_AGENT);
	}

	public static async ValueTask<IpLocateClient> ClientAsync(string apiKey, string baseUrl, int timeoutMs, string userAgent)
	{
		ArgumentException.ThrowIfNullOrEmpty(apiKey, nameof(apiKey));
		ArgumentException.ThrowIfNullOrEmpty(baseUrl, nameof(baseUrl));
		ArgumentOutOfRangeException.ThrowIfNegative(timeoutMs, nameof(timeoutMs));

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
		return await ValueTask.FromResult(new IpLocateClient(httpClient));
	}
}
