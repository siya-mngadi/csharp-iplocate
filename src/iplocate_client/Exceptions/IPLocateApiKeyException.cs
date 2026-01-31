using System.Net;

namespace IpLocateClient.Exceptions;

public class IPLocateApiKeyException : IPLocateApiException
{
	public IPLocateApiKeyException(string message) 
		: base(message, HttpStatusCode.Forbidden)
	{
	}
}
