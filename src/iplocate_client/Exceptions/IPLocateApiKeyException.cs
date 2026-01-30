using System.Net;

namespace iplocate_client.Exceptions;

public class IPLocateApiKeyException : IPLocateApiException
{
	public IPLocateApiKeyException(string message) 
		: base(message, HttpStatusCode.Forbidden)
	{
	}
}
