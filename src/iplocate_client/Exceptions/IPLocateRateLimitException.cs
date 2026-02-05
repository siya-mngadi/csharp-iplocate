using System.Net;

namespace IpLocate.Exceptions
{
	public class IPLocateRateLimitException : IPLocateApiException
	{
		public IPLocateRateLimitException(string message)
			:base(message, HttpStatusCode.TooManyRequests)
		{
		}
	}
}
