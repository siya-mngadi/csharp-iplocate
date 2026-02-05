using Newtonsoft.Json;


namespace IpLocate.Models
{
	public class ErrorResponse
	{
		[JsonProperty("error")]
		public string Error { get; set; }
		public override string ToString()
		{
			return $"{GetType().Name}: [error = {Error}]";
		}
	}
}
