using System;
using System.Net;

namespace IpLocate.Exceptions
{
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
}
