using Newtonsoft.Json;

namespace IpLocate.Models
{
	public class AsnDetails
	{
		[JsonProperty("asn")]
		public string Asn { get; set; }
		[JsonProperty("route")]
		public string Route { get; set; }
		[JsonProperty("netname")]
		public string Netname { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("country_code")]
		public string CountryCode { get; set; }
		[JsonProperty("domain")]
		public string Domain { get; set; }
		[JsonProperty("type")]
		public string Type { get; set; }
		[JsonProperty("rir")]
		public string Rir { get; set; }
		public override string ToString()
		{
			return $"{GetType().Name}: [asn = {Asn}, name={Name}]";
		}
	}
}
