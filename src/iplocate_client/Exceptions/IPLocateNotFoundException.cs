using System.Net;

namespace IpLocateClient.Exceptions;

public class IPLocateNotFoundException : IPLocateApiException
{
	public IPLocateNotFoundException(string message) 
		: base(message, HttpStatusCode.NotFound)
	{
		
	}
}
