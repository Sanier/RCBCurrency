using System.Text.Json.Serialization;

namespace RCBCurrency.Domain.ViewModels
{
    public class CurrencyOutputViewModel
    {
        public required string CharCode { get; set; }
        public long Nominal { get; set; }
        public required string Name { get; set; }
        public double Value { get; set; }
    }
}
