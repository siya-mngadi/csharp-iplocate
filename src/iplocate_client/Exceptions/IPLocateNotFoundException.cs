using System.Net;

namespace iplocate_client.Exceptions;

public class IPLocateNotFoundException : IPLocateApiException
{
	public IPLocateNotFoundException(string message) 
		: base(message, HttpStatusCode.NotFound)
	{
		
	}
}
