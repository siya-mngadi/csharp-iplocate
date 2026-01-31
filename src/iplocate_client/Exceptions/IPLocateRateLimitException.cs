using System.Net;

namespace IpLocateClient.Exceptions;

public class IPLocateRateLimitException : IPLocateApiException
{
	public IPLocateRateLimitException(string message)
		:base(message, HttpStatusCode.TooManyRequests)
	{
	}
}
