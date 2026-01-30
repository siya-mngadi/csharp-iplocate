
using System.Net;

namespace iplocate_client.Exceptions;

public class IPLocateApiException : HttpRequestException
{
	public IPLocateApiException(string message, HttpStatusCode statusCode)
		: base(message, null, statusCode)
	{
	}

	public IPLocateApiException(string message, HttpStatusCode statusCode, Exception innerException) 
		: base(message, innerException, statusCode)
	{
	}
}
