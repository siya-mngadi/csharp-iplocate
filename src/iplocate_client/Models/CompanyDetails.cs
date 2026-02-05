using Newtonsoft.Json;

namespace IpLocate.Models
{
	public class CompanyDetails
	{
		[JsonProperty("domain")]
		public string Domain { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("country_code")]
		public string CountryCode { get; set; }
		[JsonProperty("type")]
		public string Type { get; set; }
		public override string ToString()
		{
			return $"{GetType().Name}: [ name = {Name}, Domain = {Domain}]";
		}
	}
}
