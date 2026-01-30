using System.Net;

namespace iplocate_client.Exceptions;

public class IPLocateInvalidIPException : IPLocateApiException
{
	public IPLocateInvalidIPException(string message)
		: base(message, HttpStatusCode.BadRequest)
	{
		
	}
}
