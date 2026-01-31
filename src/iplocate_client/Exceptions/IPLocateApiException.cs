
using System.Net;

namespace IpLocate.Exceptions;

public class IPLocateApiException : Exception
{
	public HttpStatusCode StatusCode { get; init; }
	public IPLocateApiException(string message, HttpStatusCode statusCode)
		: base(message)
	{
		StatusCode = statusCode; 
	}

	public IPLocateApiException(string message, HttpStatusCode statusCode, Exception innerException) 
		: base(message, innerException)
	{
		StatusCode = statusCode;
	}
}
