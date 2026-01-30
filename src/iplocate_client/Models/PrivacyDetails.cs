using System.Text.Json.Serialization;

namespace iplocate_client.Models;

public class PrivacyDetails
{
	[JsonPropertyName("is_abuser")]
	public bool Abuser { get; set; }

	[JsonPropertyName("is_anonymous")]
	public bool Anonymous { get; set; }

	[JsonPropertyName("is_bogon")]
	public bool Bogon { get; set;  }

	[JsonPropertyName("is_hosting")]
	public bool Hosting { get; set; }

	[JsonPropertyName("is_icloud_relay")]
	public bool IcloudRelay { get; set; }

	[JsonPropertyName("is_proxy")]
	public bool Proxy { get; set; }

	[JsonPropertyName("is_tor")]
	public bool Tor { get; set; }

	[JsonPropertyName("is_vpn")]
	public bool Vpn { get; set; }

	public override string ToString()
	{
		return $"{GetType().Name}: [VPN = {Vpn}, Proxy = {Proxy}, Tor = {Tor}]";
	}
}