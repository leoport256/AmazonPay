using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

/// <summary>
/// Country-based address restrictions.
/// </summary>
public sealed class AddressRestrictions
{
	/// <summary>
	/// Specifies whether addresses that match restrictions configuration should or should not be restricted. Supported values: Allowed / NotAllowed.
	/// </summary>
	[JsonProperty("type")]
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
	[JsonProperty("restrictions")]
	public Dictionary<string, Restriction> Restrictions { get; } = new();
}