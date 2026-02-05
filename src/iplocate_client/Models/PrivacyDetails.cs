using Newtonsoft.Json;

namespace IpLocate.Models
{
	public class PrivacyDetails
	{
		[JsonProperty("is_abuser")]
		public bool Abuser { get; set; }

		[JsonProperty("is_anonymous")]
		public bool Anonymous { get; set; }

		[JsonProperty("is_bogon")]
		public bool Bogon { get; set;  }

		[JsonProperty("is_hosting")]
		public bool Hosting { get; set; }

		[JsonProperty("is_icloud_relay")]
		public bool IcloudRelay { get; set; }

		[JsonProperty("is_proxy")]
		public bool Proxy { get; set; }

		[JsonProperty("is_tor")]
		public bool Tor { get; set; }

		[JsonProperty("is_vpn")]
		public bool Vpn { get; set; }

		public override string ToString()
		{
			return $"{GetType().Name}: [VPN = {Vpn}, Proxy = {Proxy}, Tor = {Tor}]";
		}
	}
}