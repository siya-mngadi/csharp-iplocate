using System.Net;

namespace IpLocate.Exceptions
{
	public class IPLocateNotFoundException : IPLocateApiException
	{
		public IPLocateNotFoundException(string message) 
			: base(message, HttpStatusCode.NotFound)
		{
		}
	}
}
