using Microsoft.AspNetCore.Mvc;
using RCBCurrency.Controllers;
using RCBCurrency.Services.Implementation;
using RCBCurrency.Services.Interfaces;

namespace RCBCurrency.Tests.Controllers
{
    [TestFixture]
    public class CurrenciesDataControllerTest
    {
        private ICurrencyService _currencyService;

        private CurrenciesDataController _controller;

        [SetUp]
        public void Setup()
        {
            _currencyService = new CurrencyService();
            _controller = new CurrenciesDataController(_currencyService);
        }

        [Test]
        public async Task Currencies_ReturnsView_WhenStatusCodeIsSuccess()
        {
            var result = await _controller.Currencies() as ViewResult;

            Assert.IsNotNull(result?.Model);
            Assert.That(result, Is.InstanceOf<ViewResult>());
        }
    }
}
