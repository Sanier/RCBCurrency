using Microsoft.AspNetCore.Mvc;
using Moq;
using RCBCurrency.Controllers;
using RCBCurrency.Domain.BaseResponse;
using RCBCurrency.Domain.Enums;
using RCBCurrency.Domain.ViewModels;
using RCBCurrency.Services.Interfaces;

namespace RCBCurrency.Tests.Controllers
{
    [TestFixture]
    public class CurrenciesDataControllerTests
    {
        private Mock<ICurrencyService> _currencyServiceMock;
        private CurrenciesDataController _controller;

        [SetUp]
        public void Setup()
        {
            _currencyServiceMock = new Mock<ICurrencyService>();
            _controller = new CurrenciesDataController(_currencyServiceMock.Object);
        }

        [Test]
        public async Task Currencies_ReturnsView_WhenStatusCodeIsSuccess()
        {
            // Arrange
            var currencies = new List<CurrencyOutputViewModel>();
            var response = new BaseResponse<IEnumerable<CurrencyOutputViewModel>>
            {
                Data = currencies,
                StatusCode = StatusCode.Success
            };
            _currencyServiceMock.Setup(service => service.GetCurrenciesData())
                .ReturnsAsync(response);

            // Act
            var result = await _controller.Currencies();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public async Task Currencies_ReturnsBadRequest_WhenStatusCodeIsNotSuccess()
        {
            // Arrange
            var response = new BaseResponse<IEnumerable<CurrencyOutputViewModel>>
            {
                StatusCode = StatusCode.InternalServerError
            };
            _currencyServiceMock.Setup(service => service.GetCurrenciesData())
                .ReturnsAsync(response);

            // Act
            var result = await _controller.Currencies();

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }
    }
}
