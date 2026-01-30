using System.Text.Json.Serialization;

namespace iplocate_client.Models;

public class AsnDetails
{
	[JsonPropertyName("asn")]
	public string Asn { get; set; }
	[JsonPropertyName("route")]
	public string Route { get; set; }
	[JsonPropertyName("netname")]
	public string Netname { get; set; }
	[JsonPropertyName("name")]
	public string Name { get; set; }
	[JsonPropertyName("country_code")]
	public string CountryCode { get; set; }
	[JsonPropertyName("domain")]
	public string Domain { get; set; }
	[JsonPropertyName("type")]
	public string Type { get; set; }
	[JsonPropertyName("rir")]
	public string Rir { get; set; }
	public override string ToString()
	{
		return $"{GetType().Name}: [asn = {Asn}, name={Name}]";
	}
}
