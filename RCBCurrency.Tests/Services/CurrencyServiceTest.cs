using RCBCurrency.Domain.Enums;
using RCBCurrency.Services.Implementation;
using RCBCurrency.Services.Interfaces;

namespace RCBCurrency.Tests.Services
{
    [TestFixture]
    public class CurrencyServiceTest
    {
        private ICurrencyService _currencyService;

        [SetUp]
        public void Setup()
        {
            _currencyService = new CurrencyService();
        }

        [Test]
        public async Task GetCurrenciesData_ReturnsSuccessStatusCode_WhenCalledWithValidData()
        {
            // Arrange
            var expectedStatusCode = StatusCode.Success;

            // Act
            var result = await _currencyService.GetCurrenciesData();

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(expectedStatusCode));
        }
    }
}
