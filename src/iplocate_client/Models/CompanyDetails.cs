using System.Text.Json.Serialization;

namespace IpLocateClient.Models;

public class CompanyDetails
{
	[JsonPropertyName("domain")]
	public string Domain { get; set; }
	[JsonPropertyName("name")]
	public string Name { get; set; }
	[JsonPropertyName("country_code")]
	public string CountryCode { get; set; }
	[JsonPropertyName("type")]
	public string Type { get; set; }
	public override string ToString()
	{
		return $"{GetType().Name}: [ name = {Name}, Domain = {Domain}]";
	}
}
