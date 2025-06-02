using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

public sealed class Constraint
{
	/// <summary>
	/// Code for any Checkout Session constraint(s).
	/// </summary>
	[JsonPropertyName("constraintId")]
	public required string ConstraintId { get; set; }

	/// <summary>
	/// Description of the Checkout Session constraint(s).
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }
}