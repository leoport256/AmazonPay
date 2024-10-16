using System.Text.Json;
using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public static class AmazonPayJsonSerializerOptions
{
	public static JsonSerializerOptions JsonSerializerOptions => CreateJsonSerializerOptions(); 
	private static JsonSerializerOptions CreateJsonSerializerOptions()
	{
		var options = new JsonSerializerOptions
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
			UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement,
			WriteIndented = false
		};

		options.Converters.Add(new DateTimeIso8601JsonConverter());
		options.Converters.Add(new DateTimeIso8601NullableJsonConverter());
		return options;
	}
}