using System.Text.Json.Serialization;

namespace IpLocateClient.Models;

public class AbuseDetails
{
	[JsonPropertyName("address")]
	public string Address { get; set; }
	[JsonPropertyName("country_code")]
	public string CountryCode { get; set; }
	[JsonPropertyName("email")]
	public string Email { get; set; }
	[JsonPropertyName("name")]
	public string Name { get; set; }
	[JsonPropertyName("network")]
	public string Network { get; set; }
	[JsonPropertyName("phone")]
	public string Phone { get; set; }
	public override string ToString()
	{
		return $"{GetType().Name}: [name = {Name}, email={Email}]";
	}
}
