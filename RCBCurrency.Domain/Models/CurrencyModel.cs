using System.Text.Json.Serialization;

namespace RCBCurrency.Domain.Models
{
    public class CurrencyModel
    {
        [JsonPropertyName("ID")]
        public required string Id { get; set; }

        [JsonPropertyName("NumCode")]
        public required string NumCode { get; set; }

        [JsonPropertyName("CharCode")]
        public required string CharCode { get; set; }

        [JsonPropertyName("Nominal")]
        public long Nominal { get; set; }

        [JsonPropertyName("Name")]
        public required string Name { get; set; }

        [JsonPropertyName("Value")]
        public double Value { get; set; }

        [JsonPropertyName("Previous")]
        public double Previous { get; set; }
    }
}
