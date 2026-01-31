using System.Text.Json.Serialization;

namespace IpLocate.Models;

public class HostingDetails
{
	[JsonPropertyName("provider")]
	public string Provider { get; set; }

	[JsonPropertyName("domain")]
	public string Domain {get;set;}
	[JsonPropertyName("network")]
	public string Network {get;set;}
	[JsonPropertyName("region")]
	public string Region {get;set;}
	[JsonPropertyName("service")]
	public string Service {get;set;}
	
	public override string ToString()
	{
		return $"{GetType().Name}: [provider = {Provider}, service = {Service}]";
	}
}
