using Newtonsoft.Json;

namespace IpLocate.Models
{
	public class HostingDetails
	{
		[JsonProperty("provider")]
		public string Provider { get; set; }

		[JsonProperty("domain")]
		public string Domain {get;set;}
		[JsonProperty("network")]
		public string Network {get;set;}
		[JsonProperty("region")]
		public string Region {get;set;}
		[JsonProperty("service")]
		public string Service {get;set;}
	
		public override string ToString()
		{
			return $"{GetType().Name}: [provider = {Provider}, service = {Service}]";
		}
	}
}
