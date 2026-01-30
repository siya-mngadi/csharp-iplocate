using System.Net;

namespace iplocate_client.Exceptions;

public class IPLocateRateLimitException : IPLocateApiException
{
	public IPLocateRateLimitException(string message)
		:base(message, HttpStatusCode.TooManyRequests)
	{
	}
}
