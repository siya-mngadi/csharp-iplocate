using System.Text.Json.Serialization;

namespace iplocate_client.Models;

public class ErrorResponse
{
	[JsonPropertyName("error")]
	public string Error { get; set; }
	public override string ToString()
	{
		return $"{GetType().Name}: [error = {Error}]";
	}
}
