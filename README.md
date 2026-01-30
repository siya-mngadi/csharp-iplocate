# IPLocate Geolocation Client for C#

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

[![NuGet](https://img.shields.io/nuget/v/IpLocate.svg?style=flat-square)](https://www.nuget.org/packages/IpLocate/)


A C# client for the [IPLocate.io](https://iplocate.io) geolocation API. Look up detailed geolocation and threat intelligence data for any IP address:

- **IP geolocation**: IP to country, IP to city, IP to region/state, coordinates, timezone, postal code
- **ASN information**: Internet service provider, network details, routing information
- **Privacy & threat detection**: VPN, proxy, Tor, hosting provider detection
- **Company information**: Business details associated with IP addresses - company name, domain, type (ISP/hosting/education/government/business)
- **Abuse contact**: Network abuse reporting information
- **Hosting detection**: Cloud provider and hosting service detection using our proprietary hosting detection engine

See what information we can provide for [your IP address](https://iplocate.io/what-is-my-ip).

## Getting started

You can make 1,000 free requests per day with a [free account](https://iplocate.io/signup). For higher plans, check out [API pricing](https://www.iplocate.io/pricing).

## Installation

### .NET CLI
```cmd
dotnet add package IpLocate
```

## Authentication

Get your free API key from [IPLocate.io](https://iplocate.io/signup), and pass it to the `IPLocateClient` constructor:

```csharp
IPLocateClient client = new IpLocateHttpClient("your-api-key");
```

### Quick start

```csharp
using IpLocate;

var client = new IpLocateHttpClient("YOUR_API_KEY");
var result = await client.LookupCurrentIpAsync();

Console.WriteLine($"IP: {result.Ip}, Country: {result.Country}");
```

