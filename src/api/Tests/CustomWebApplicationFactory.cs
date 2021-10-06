using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Service;
using ServiceDiscovery;
using WebApi;

namespace Tests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
    {
        public Mock<IDependencyService> DependencyService { get; set; }
        public Mock<IUrlProvider> ServiceDiscovery { get; set; }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
            builder.ConfigureTestServices(services =>
            {
                this.ServiceDiscovery = new Mock<IUrlProvider>();
                services.Remove(services.SingleOrDefault(d => d.ServiceType == typeof(IUrlProvider)));
                services.AddTransient<IUrlProvider>(s => this.ServiceDiscovery.Object);

                this.DependencyService = new Mock<IDependencyService>();
                services.Remove(services.SingleOrDefault(d => d.ServiceType == typeof(IDependencyService)));
                services.AddTransient<IDependencyService>(s => this.DependencyService.Object);
            });
        }
    }
}