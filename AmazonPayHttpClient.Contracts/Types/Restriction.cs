using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class Restriction
{
	/// <summary>
	/// List of country-specific states that should or should not be restricted based on addressRestrictions.type parameter.
	/// </summary>
	[JsonIgnore]
	public List<string> StatesOrRegions { get; private set; } = new();

	[JsonPropertyName("statesOrRegions")]
	public List<string>? StatesOrRegionsRaw
	{
		get => StatesOrRegions.Any() ? StatesOrRegions : null;
		set => StatesOrRegions = value is null || !value.Any() ? new List<string>() : value;
	}

	/// <summary>
	/// List of country-specific zip codes that should or should not be restricted based on addressRestrictions.type parameter
	/// </summary>
	[JsonIgnore]
	public List<string> ZipCodes { get; private set; } = new();

	[JsonPropertyName("zipCodes")]
	public List<string>? ZipCodesRaw
	{
		get => ZipCodes.Any() ? ZipCodes : null;
		set => ZipCodes = value is null || !value.Any() ? new List<string>() : value;
	}
}