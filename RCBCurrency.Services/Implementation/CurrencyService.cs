using System.Text.Json;
using System.Threading.Tasks;
using RCBCurrency.Domain.BaseResponse;
using RCBCurrency.Domain.Enums;
using RCBCurrency.Domain.Models;
using RCBCurrency.Domain.ViewModels;
using RCBCurrency.JSON.Interfaces;
using RCBCurrency.JsonDeserialize;
using RCBCurrency.Services.Interfaces;

namespace RCBCurrency.Services.Implementation
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ILoadJson _loadJson;

        public CurrencyService(ILoadJson loadJson)
        {
            _loadJson = loadJson;
        }

        public async Task<IBaseResponse<IEnumerable<CurrencyOutputViewModel>>> GetCurrenciesData()
        {
            try
            {
                await _loadJson.LoadJsonToFile();

                var jsonFile = await File.ReadAllTextAsync("./Currencies.json");
                var targetCharCodes = new List<string> { "USD", "EUR", "CNY" };

                if (string.IsNullOrEmpty(jsonFile))
                    throw new ArgumentNullException();

                var response = JsonSerializer.Deserialize<CurrencySerializeModel>(jsonFile);
                var filteredCurrencies = response?.CurrencyModel
                    .Where(v => targetCharCodes.Contains(v.Value.CharCode))
                    .Select(v => new CurrencyOutputViewModel
                    {
                        CharCode = v.Value.CharCode,
                        Nominal = v.Value.Nominal,
                        Name = v.Value.Name,
                        Value = v.Value.Value
                    })
                    .ToList();

                if (filteredCurrencies is null)
                    throw new ArgumentNullException();

                return new BaseResponse<IEnumerable<CurrencyOutputViewModel>>()
                {
                    Data = filteredCurrencies,
                    StatusCode = StatusCode.Success,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<CurrencyOutputViewModel>>()
                {
                    Description = $"{ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}