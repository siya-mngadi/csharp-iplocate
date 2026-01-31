using System.Net;

namespace IpLocateClient.Exceptions;

public class IPLocateInvalidIPException : IPLocateApiException
{
	public IPLocateInvalidIPException(string message)
		: base(message, HttpStatusCode.BadRequest)
	{
		
	}
}
