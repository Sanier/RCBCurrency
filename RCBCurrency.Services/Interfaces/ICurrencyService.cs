using RCBCurrency.Domain.BaseResponse;
using RCBCurrency.Domain.Models;
using RCBCurrency.Domain.ViewModels;

namespace RCBCurrency.Services.Interfaces
{
    public interface ICurrencyService
    {
        Task<IBaseResponse<IEnumerable<CurrencyOutputViewModel>>> GetCurrenciesData();
    }
}
