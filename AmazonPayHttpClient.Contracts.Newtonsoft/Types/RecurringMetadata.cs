using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class RecurringMetadata
{
	/// <summary>
	/// Recurring metadata charge frequency
	/// </summary>
	[JsonIgnore]
	public Frequency Frequency { get; private set; } = new();

	[JsonProperty("frequency")]
	public Frequency? FrequencyRaw
	{
		get => IsEmpty ? null : Frequency;
		set => Frequency = value is null || value.IsEmpty ? new Frequency() : value;
	}


	/// <summary>
	/// Optional metadata transaction amount
	/// </summary>
	[JsonIgnore]
	public Price Amount { get; private set; } = new();

	[JsonProperty("amount")]
	public Price? AmountRaw
	{
		get => IsEmpty ? null : Amount;
		set => Amount = (value is null || value.IsEmpty) ? new Price() : value;
	}

	[JsonIgnore]
	public bool IsEmpty => Frequency.IsEmpty && Amount.IsEmpty;
}