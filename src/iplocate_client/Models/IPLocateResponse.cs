using System.Text.Json.Serialization;

namespace IpLocate.Models;

public class IPLocateResponse
{
	[JsonPropertyName("ip")]
	public string Ip { get; set;  }
	[JsonPropertyName("country")]
	public string Country { get; set; }
	[JsonPropertyName("country_code")]
	public string CountryCode { get; set; }
	[JsonPropertyName("is_eu")]
	public bool? Eu { get; set; }
	[JsonPropertyName("city")]
	public string City { get; set; }
	[JsonPropertyName("continent")]
	public string Continent { get; set; }
	[JsonPropertyName("latitude")]
	public double? Latitude { get; set; }
	[JsonPropertyName("longitude")]
	public double? Longitude { get; set; }
	[JsonPropertyName("time_zone")]
	public string TimeZone { get; set; }
	[JsonPropertyName("postal_code")]
	 public string PostalCode { get; set; }
	[JsonPropertyName("subdivision")]
	public string Subdivision { get; set; }
	[JsonPropertyName("currency_code")]
	public string CurrencyCode { get; set; }
	[JsonPropertyName("calling_code")]	
	public string CallingCode { get; set; }
	[JsonPropertyName("network")]
	public string Network { get; set; }

	public AsnDetails Asn { get; set; }
	public PrivacyDetails Privacy { get; set; }
	public CompanyDetails Company { get; set; }
	public HostingDetails Hosting { get; set; }
	public AbuseDetails Abuse { get; set; }

	public override string ToString()
	{
		return $"{GetType().Name}: [IP = {Ip}, Country = {Country}, City = {City}]";
	}
}
