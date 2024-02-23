using System.Text.Json.Serialization;

namespace RCBCurrency.Domain.Models
{
    public class CurrencySerializeModel
    {
        [JsonPropertyName("Date")]
        public DateTimeOffset Date { get; set; }

        [JsonPropertyName("PreviousDate")]
        public DateTimeOffset PreviousDate { get; set; }

        [JsonPropertyName("PreviousURL")]
        public required string PreviousUrl { get; set; }

        [JsonPropertyName("Timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonPropertyName("Valute")]
        public required Dictionary<string, CurrencyModel> CurrencyModel { get; set; }
    }
}
