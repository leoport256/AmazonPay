using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class Constraint
{
	/// <summary>
	/// Code for any Checkout Session constraint(s).
	/// </summary>
	[JsonProperty("constraintId")]
	public required string ConstraintId { get; set; }

	/// <summary>
	/// Description of the Checkout Session constraint(s).
	/// </summary>
	[JsonProperty("description")]
	public string? Description { get; set; }
}