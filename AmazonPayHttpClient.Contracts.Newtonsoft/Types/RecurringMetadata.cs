using Newtonsoft.Json;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

public sealed class RecurringMetadata
{
    public RecurringMetadata()
    {
        Frequency = new Frequency();
        Amount = new Price();
    }

    /// <summary>
    /// Recurring metadata charge frequency
    /// </summary>
    [JsonIgnore]
    public Frequency Frequency { get; private set; }

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
    public Price Amount { get; set; }

    [JsonProperty("amount")]
    public Price? AmountRaw  => IsEmpty ? null : Amount;
        
    [JsonIgnore]
    public bool IsEmpty => (Frequency.IsEmpty) && (Amount.IsEmpty);
}