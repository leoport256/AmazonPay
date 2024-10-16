using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts
{
    public sealed class DeliverySpecifications
    {
        public DeliverySpecifications()
        {
            SpecialRestrictions = new List<SpecialRestriction>();
            AddressRestrictions = new AddressRestrictions();
        }

        /// <summary>
        /// Special restrictions, for example to prohibit buyers from selecting PO boxes.
        /// </summary>
        [JsonIgnore]
        public List<SpecialRestriction> SpecialRestrictions { get; private set; }


        [JsonPropertyName("specialRestrictions")]
        public List<SpecialRestriction>? SpecialRestrictionsRaw
        {
            get => SpecialRestrictions.Any() ? SpecialRestrictions : null;
            set => SpecialRestrictions = value is null || !value.Any() ? new List<SpecialRestriction>() : value;
        }

        /// <summary>
        /// Country-based address restrictions.
        /// </summary>
        [JsonIgnore]
        public AddressRestrictions AddressRestrictions { get; private set; }

        [JsonPropertyName("addressRestrictions")]
        public AddressRestrictions? AddressRestrictionsRaw
        {
            get => AddressRestrictions.IsEmpty ? null : AddressRestrictions;
            set => AddressRestrictions = value is null || value.IsEmpty ? new AddressRestrictions() : value;
        }
    }
}
