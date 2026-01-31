using IpLocate.Exceptions;
using IpLocate.Models;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace IpLocate;

public sealed class IpLocateClient
{
	private readonly HttpClient _client;
	private readonly JsonSerializerOptions jsonOptions = new(JsonSerializerDefaults.Web)
	{
		PropertyNameCaseInsensitive = true,
	};
	public IpLocateClient(HttpClient client)
	{
		_client = client;
	}

	public async ValueTask<IPLocateResponse> LookupAsync(string ipAddress)
	{
		if (string.IsNullOrWhiteSpace(ipAddress))
		{
			throw new ArgumentException("IP address cannot be null or empty", nameof(ipAddress));
		}
		if (_cache.TryGetValue(ipAddress, out var cachedResult)) return cachedResult;
		var result = await performLookup(ipAddress);
		return result;
	}

	public async ValueTask<IPLocateResponse> LookupCurrentIpAsync()
	{
		var result = await performLookup(null);
		_cache.TryAdd(result.Ip, result);
		return result;
	}

	private async ValueTask<IPLocateResponse> performLookup(string ipAddressPathSegment)
	{
		var lookupPath = string.IsNullOrWhiteSpace(ipAddressPathSegment) ? "api/lookup" : $"api/lookup/{ipAddressPathSegment}";
		if (!Uri.TryCreate(_client.BaseAddress, lookupPath, out var url))
		{
			throw new ArgumentException("Failed to create valid URL for IPLocate API request.");
		}

		var request = new HttpRequestMessage(HttpMethod.Get, url.AbsolutePath);

		try
		{
			var response = await _client.SendAsync(request);
			if (response.IsSuccessStatusCode)
			{
				try
				{
					return await response.Content.ReadFromJsonAsync<IPLocateResponse>(jsonOptions);
				}
				catch (JsonException ex)
				{
					throw new IPLocateServiceException("Failed to parse IPLocate API response: " + ex.Message, response.StatusCode, ex);
				}
			}
			else
			{
				await handleErrorResponse(response);
				// Should not be reached as handleErrorResponse is always thrown
				throw new IPLocateServiceException("Unexpected state after error handling.", response.StatusCode);
			}
		}
		catch (HttpRequestException ex)
		{
			throw new IPLocateServiceException($"Network error or problem reaching IPLocate API: {ex.Message}", HttpStatusCode.ServiceUnavailable, ex);
		}
	}

	private async Task handleErrorResponse(HttpResponseMessage response)
	{
		var statusCode = response.StatusCode;
		string errorBodyString;

		try
		{
			var body = await response.Content.ReadAsStringAsync();
			errorBodyString = body ?? "";
		}
		catch (JsonException ex)
		{
			// This might happen if reading the error body itself fails.
			// We still want to throw based on status code.
			errorBodyString = "Failed to read error response body. Cause: " + ex.Message;
		}

		if (string.IsNullOrWhiteSpace(errorBodyString))
		{
			errorBodyString = "No error body received from server. Status code: " + statusCode;
		}

		if (statusCode >= HttpStatusCode.BadRequest && statusCode < HttpStatusCode.InternalServerError)
		{
			try
			{
				var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>(jsonOptions);
				var errorMessage = errorResponse?.Error ?? "Unknown error";

				throw statusCode switch
				{
					HttpStatusCode.BadRequest => new IPLocateInvalidIPException(errorMessage),
					HttpStatusCode.Forbidden => new IPLocateApiKeyException(errorMessage),
					HttpStatusCode.NotFound => new IPLocateNotFoundException(errorMessage),
					HttpStatusCode.TooManyRequests => new IPLocateRateLimitException(errorMessage),
					_ => new IPLocateApiException("API error: " + errorMessage, statusCode),
				};
			}
			catch (JsonException)
			{
				string baseMessage = "API request failed with status code " + statusCode +
									  ". Unable to parse error response. Raw error: " + errorBodyString;
				throw statusCode switch
				{
					HttpStatusCode.BadRequest => new IPLocateInvalidIPException(baseMessage),
					HttpStatusCode.Forbidden => new IPLocateApiKeyException(baseMessage),
					HttpStatusCode.NotFound => new IPLocateNotFoundException(baseMessage),
					HttpStatusCode.TooManyRequests => new IPLocateRateLimitException(baseMessage),
					_ => new IPLocateApiException("API error: " + baseMessage, statusCode),
				};
			}
			throw new IPLocateServiceException($"Authentication failed with status code {statusCode}. Response body: {errorBodyString}", statusCode);
		}
		else if (statusCode >= HttpStatusCode.InternalServerError)
		{
			throw new IPLocateServiceException($"Server error: {errorBodyString}", statusCode);
		}
		else
		{
			throw new IPLocateApiException($"Unexpected  Http status code: {statusCode}. Response: {errorBodyString}", statusCode);
		}
	}
}
