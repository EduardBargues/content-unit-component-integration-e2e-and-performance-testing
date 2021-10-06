using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ServiceDiscovery
{
    public class UrlProvider : IUrlProvider
    {
        private readonly ILogger<UrlProvider> _logger;

        public UrlProvider(ILogger<UrlProvider> logger)
        {
            _logger = logger;
        }

        public async Task<string> GetUrlAsync(string serviceName)
        {
            _logger.LogWarning($"obtaining service-discovery url from env.var {Constants.SERVICE_DISCOVERY_URL_ENV_VAR_NAME} ...");
            var url = Environment.GetEnvironmentVariable(Constants.SERVICE_DISCOVERY_URL_ENV_VAR_NAME);
            _logger.LogWarning($"service-discovery url is {url}");
            var fullUrl = $"{url}/discover?serviceName={serviceName}";
            _logger.LogWarning($"discovering service {serviceName} by calling {fullUrl} ...");

            using (HttpClient client = new HttpClient())
            using (var response = await client.GetAsync(fullUrl))
            {
                var serviceUrl = await response.Content.ReadAsStringAsync();
                _logger.LogWarning($"service-discovery responded with {serviceUrl}");
                return serviceUrl;
            }
        }
    }
}
