using Moq;
using RCBCurrency.Domain.Enums;
using RCBCurrency.JSON.Interfaces;
using RCBCurrency.Services.Implementation;

namespace RCBCurrency.Tests.Services
{
    [TestFixture]
    public class CurrencyServiceTests
    {
        private Mock<ILoadJson> _loadJsonMock;
        private CurrencyService _currencyService;

        [SetUp]
        public void Setup()
        {
            _loadJsonMock = new Mock<ILoadJson>();
            _currencyService = new CurrencyService(_loadJsonMock.Object);
        }

        [Test]
        public async Task GetCurrenciesData_ReturnsSuccessStatusCode_WhenCalledWithValidData()
        {
            // Arrange
            var expectedStatusCode = StatusCode.Success;
            _loadJsonMock.Setup(x => x.LoadJsonToFile()).Returns(Task.CompletedTask);

            // Act
            var result = await _currencyService.GetCurrenciesData();

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(expectedStatusCode));
        }

        [Test]
        public async Task GetCurrenciesData_ThrowsException_WhenLoadJsonToFileFails()
        {
            // Arrange
            var mockLoadJson = new Mock<ILoadJson>();
            mockLoadJson.Setup(x => x.LoadJsonToFile()).ThrowsAsync(new Exception());

            var currencyService = new CurrencyService(mockLoadJson.Object);

            // Act & Assert
            var result = await currencyService.GetCurrenciesData();
            Assert.That(result.StatusCode, Is.EqualTo(StatusCode.InternalServerError));
        }
    }
}
