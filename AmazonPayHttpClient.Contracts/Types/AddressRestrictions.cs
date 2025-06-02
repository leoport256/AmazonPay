using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

/// <summary>
/// Country-based address restrictions.
/// </summary>
public sealed class AddressRestrictions
{
	/// <summary>
	/// Specifies whether addresses that match restrictions configuration should or should not be restricted. Supported values: Allowed / NotAllowed.
	/// </summary>
	[JsonPropertyName("type")]
	public RestrictionType Type
	{
		get => IsAllowed ? RestrictionType.Allowed : RestrictionType.NotAllowed;
		set => IsAllowed = value == RestrictionType.Allowed;
	}

	[JsonIgnore]
	public bool IsAllowed { get; private set; }

	[JsonIgnore]
	public bool IsEmpty => !Restrictions.Any();

	/// <summary>
	/// Hash of country-level restrictions that determine which addresses should or should not be restricted.
	/// </summary>
	[JsonPropertyName("restrictions")]
	public Dictionary<string, Restriction> Restrictions { get; } = [];
}