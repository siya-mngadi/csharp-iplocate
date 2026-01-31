using System.Net;

namespace IpLocate.Exceptions;

public class IPLocateApiKeyException : IPLocateApiException
{
	public IPLocateApiKeyException(string message) 
		: base(message, HttpStatusCode.Forbidden)
	{
	}
}
