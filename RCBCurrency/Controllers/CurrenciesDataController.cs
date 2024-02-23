using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RCBCurrency.Domain.ViewModels;
using RCBCurrency.Services.Interfaces;

namespace RCBCurrency.Controllers
{
    public class CurrenciesDataController : Controller
    {
        private ICurrencyService _currencyService;

        public CurrenciesDataController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }
        public async Task<IActionResult> Currencies()
        {
            var response = await _currencyService.GetCurrenciesData();

            if (response.StatusCode == Domain.Enums.StatusCode.Success)
                return View(response.Data);

            return BadRequest(response.Description);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
