using Moq;
using Xunit;
using System.Threading.Tasks;
using System.Net;
using Service;
using ServiceDiscovery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Tests
{
    public class UnitTests
    {
        [Fact]
        public async Task Main()
        {
            // ARRANGE
            HttpStatusCode expectedStatusCode = HttpStatusCode.OK;
            var dependencyUrl = "https://www.i-am-a-url.com";
            var mockServiceDiscovery = new Mock<IUrlProvider>();
            mockServiceDiscovery
                .Setup(m => m.GetUrlAsync(Service.Constants.SERVICE_NAME))
                .ReturnsAsync(dependencyUrl);

            var dependencyResponse = HttpStatusCode.OK;
            var mockDependency = new Mock<IDependencyService>();
            mockDependency
                .Setup(m => m.DoAsync(dependencyUrl))
                .ReturnsAsync(dependencyResponse);
            var mockLogger = new Mock<ILogger<WebApi.Controllers.Controller>>();
            mockDependency
                .Setup(m => m.DoAsync(dependencyUrl))
                .ReturnsAsync(dependencyResponse);
            var controller = new WebApi.Controllers.Controller(mockDependency.Object, mockServiceDiscovery.Object, mockLogger.Object);

            // ACT
            var response = await controller.Post();

            // ASSERT
            Assert.IsType<OkResult>(response);
            var okResult = (OkResult)response;
            Assert.Equal((int)expectedStatusCode, okResult.StatusCode);
        }
    }
}
