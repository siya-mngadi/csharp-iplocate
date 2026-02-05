using Newtonsoft.Json;

namespace IpLocate.Models
{
	public class AbuseDetails
	{
		[JsonProperty("address")]
		public string Address { get; set; }
		[JsonProperty("country_code")]
		public string CountryCode { get; set; }
		[JsonProperty("email")]
		public string Email { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("network")]
		public string Network { get; set; }
		[JsonProperty("phone")]
		public string Phone { get; set; }
		public override string ToString()
		{
			return $"{GetType().Name}: [name = {Name}, email={Email}]";
		}
	}
}
