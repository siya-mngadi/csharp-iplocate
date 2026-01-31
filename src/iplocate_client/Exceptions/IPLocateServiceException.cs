using System.Net;

namespace IpLocateClient.Exceptions;

public class IPLocateServiceException : IPLocateApiException
{
	public IPLocateServiceException(string message, HttpStatusCode statusCode) 
		:base(message, statusCode)
	{
	}

	public IPLocateServiceException(string message, HttpStatusCode statusCode, Exception inner)
		: base(message, statusCode, inner)
	{		
	}
}
