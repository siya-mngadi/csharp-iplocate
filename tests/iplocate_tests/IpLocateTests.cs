using FluentAssertions;
using IpLocate.Exceptions;
using IpLocate;
using System.Net;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace iplocate_tests
{
	public class IPLocateClientTests : IDisposable
	{
		private readonly WireMockServer _server;

		public IPLocateClientTests()
		{
			_server = WireMockServer.Start(8010);
		}

		private string GetTestApiBaseUrl() => $"http://localhost:{_server.Port}/api";

		[Fact]
		public async Task Successful_lookup()
		{
			var apiKey = "test-key";
			var ip = "8.8.8.8";

			var json = """
        {
          "ip": "8.8.8.8",
          "country": "United States",
          "country_code": "US",
          "is_eu": false,
          "city": "Mountain View",
          "asn": {
            "asn": "AS15169"
          },
          "privacy": {
            "is_hosting": true
          }
        }
        """;

			_server.Given(
				Request.Create()
					.WithPath($"/api/lookup/{ip}")
					.WithHeader("apikey", apiKey)
					.UsingGet()
			)
			.RespondWith(
				Response.Create()
					.WithStatusCode(200)
					.WithHeader("Content-Type", "application/json")
					.WithBody(json.Trim())
			);

			var client = IpLocateClientFactory.Client(apiKey, GetTestApiBaseUrl());
			var response = await client.LookupAsync(ip);

			response.Should().NotBeNull();
			response.Ip.Should().Be("8.8.8.8");
			response.Country.Should().Be("United States");
			response.CountryCode.Should().Be("US");
			response.Asn.Asn.Should().Be("AS15169");
			response.Privacy.Hosting.Should().BeTrue();
		}

		[Fact]
		public async Task Successful_current_ip_lookup()
		{
			var apiKey = "current-ip-key";

			var jsonObj = new
			{
		 	  ip = "1.2.3.4",
	          country = "Somewhere",
	          country_code = "SW"
			};

			_server.Given(
				Request.Create()
					.WithPath($"/api/lookup")
					.WithHeader("apikey", apiKey)
					.UsingGet()
			)
			.RespondWith(
				Response.Create()
					.WithStatusCode(200)
					.WithHeader("Content-Type", "application/json")
					.WithBodyAsJson(jsonObj)
			);

			var client = IpLocateClientFactory.Client(apiKey, GetTestApiBaseUrl());
			var response = await client.LookupCurrentIpAsync();

			response.Ip.Should().Be("1.2.3.4");
			response.Country.Should().Be("Somewhere");
		}

		[Fact]
		public async Task Forbidden_error_throws_api_key_exception()
		{
			var apiKey = "invalid-key";
			var ip = "1.1.1.1";

			_server.Given(
				Request.Create()
					.WithPath($"/api/lookup/{ip}")
					.WithHeader("apikey", apiKey)
					.UsingGet()
			)
			.RespondWith(
				Response.Create()
					.WithStatusCode(403)
					.WithBodyAsJson(new { error = "Unknown token" })
			);

			var client = IpLocateClientFactory.Client(apiKey, GetTestApiBaseUrl());
			await Assert.ThrowsAsync<IPLocateApiKeyException>(async() => await client.LookupAsync(ip));
		}

		[Fact]
		public async Task Rate_limit_error()
		{
			var apiKey = "rate-limited-key";
			var ip = "1.1.1.1";

			_server.Given(
				Request.Create()
					.WithPath($"/api/lookup/{ip}")
					.WithHeader("apikey", apiKey)
					.UsingGet()
			)
			.RespondWith(
				Response.Create()
					.WithStatusCode(429)
					.WithBody("{\"error\":\"Rate limit exceeded\"}")
			);

			var client = IpLocateClientFactory.Client(apiKey, GetTestApiBaseUrl());
			await Assert.ThrowsAsync<IPLocateRateLimitException>(async ()  => await client.LookupAsync(ip));
		}

		[Fact]
		public async Task Server_error_throws_service_exception()
		{
			var apiKey = "any-key";
			var ip = "1.2.3.4";

			_server.Given(
				Request.Create()
					.WithPath($"/api/lookup/{ip}")
					.WithHeader("apikey", apiKey)
					.UsingGet()
			)
			.RespondWith(
				Response.Create()
					.WithStatusCode(500)
					.WithBody("Internal server error")
			);

			var client = IpLocateClientFactory.Client(apiKey, GetTestApiBaseUrl());

			var ex = await Assert.ThrowsAsync<IPLocateServiceException>(async() => await client.LookupAsync(ip));
			ex.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
			ex.Message.Should().Contain("Internal server error");
		}

		[Fact]
		public void Null_api_key_throws()
		{
			Assert.Throws<ArgumentException>(() => IpLocateClientFactory.Client(null));
		}

		[Fact]
		public void Empty_api_key_throws()
		{
		  Assert.Throws<ArgumentException>(() => IpLocateClientFactory.Client(string.Empty));
		}

		public void Dispose()
		{
			_server.Stop();
			_server.Dispose();
		}
	}
}
