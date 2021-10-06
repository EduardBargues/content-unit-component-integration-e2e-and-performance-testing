using Moq;
using Xunit;
using System.Threading.Tasks;
using System;
using System.Net;

namespace Tests
{
    public class ComponentTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public ComponentTests(CustomWebApplicationFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        [Fact]
        public async Task Main()
        {
            // ARRANGE
            var expectedStatusCode = HttpStatusCode.OK;

            var client = _factory.CreateClient();
            var dependencyUrl = "https://www.i-am-a-url.com";
            _factory.ServiceDiscovery
                .Setup(m => m.GetUrlAsync(Service.Constants.SERVICE_NAME))
                .ReturnsAsync(dependencyUrl);
            var dependencyResponse = HttpStatusCode.OK;
            _factory.DependencyService
                .Setup(m => m.DoAsync(dependencyUrl))
                .ReturnsAsync(dependencyResponse);

            // ACT
            var response = await client.GetAsync("dotnet-webapi");

            // ASSERT
            Assert.NotNull(response);
            Assert.Equal(expectedStatusCode, response.StatusCode);
            var body = await response.Content.ReadAsStringAsync();
            Assert.Contains($"{dependencyResponse}", body);
        }
    }
}
