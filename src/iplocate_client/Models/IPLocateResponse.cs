using Newtonsoft.Json;

namespace IpLocate.Models
{
	public class IPLocateResponse
	{
		[JsonProperty("ip")]
		public string Ip { get; set;  }
		[JsonProperty("country")]
		public string Country { get; set; }
		[JsonProperty("country_code")]
		public string CountryCode { get; set; }
		[JsonProperty("is_eu")]
		public bool? Eu { get; set; }
		[JsonProperty("city")]
		public string City { get; set; }
		[JsonProperty("continent")]
		public string Continent { get; set; }
		[JsonProperty("latitude")]
		public double? Latitude { get; set; }
		[JsonProperty("longitude")]
		public double? Longitude { get; set; }
		[JsonProperty("time_zone")]
		public string TimeZone { get; set; }
		[JsonProperty("postal_code")]
		 public string PostalCode { get; set; }
		[JsonProperty("subdivision")]
		public string Subdivision { get; set; }
		[JsonProperty("currency_code")]
		public string CurrencyCode { get; set; }
		[JsonProperty("calling_code")]	
		public string CallingCode { get; set; }
		[JsonProperty("network")]
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
}
