using iplocate_client.Models;

namespace iplocate_client;

public interface IPLocateService
{
	/// <summary>
	/// Asynchronously retrieves geolocation information for the specified IP address.	
	/// </summary>
	/// <param name="ipAddress">The IPv4 or IPv6 address to look up. Must be a valid IP address format.</param>
	/// <returns>The task result contains an <see cref="IPLocateResponse"/> with
	/// geolocation details for the specified IP address.</returns>
	ValueTask<IPLocateResponse> LookupAsync(string ipAddress);

	/// <summary>
	/// Asynchronously retrieves geolocation information for the current public IP address.
	/// </summary>
	/// <returns>The task result contains an <see cref="IPLocateResponse"/> with
	/// geolocation details for the current IP address.</returns>
	ValueTask<IPLocateResponse> LookupCurrentIpAsync();
}
