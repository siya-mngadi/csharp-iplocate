using System.Net;

namespace IpLocate.Exceptions
{
	public class IPLocateInvalidIPException : IPLocateApiException
	{
		public IPLocateInvalidIPException(string message)
			: base(message, HttpStatusCode.BadRequest)
		{
		}
	}
}
