using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServiceDiscovery
{
    public class UrlProvider : IUrlProvider
    {
        private readonly string _url = Environment.GetEnvironmentVariable(Constants.SERVICE_DISCOVERY_URL_ENV_VAR_NAME);

        public async Task<string> GetUrlAsync(string serviceName)
        {
            using (HttpClient client = new HttpClient())
            using (var response = await client.GetAsync($"{_url}?serviceName={serviceName}"))
            {
                var serviceUrl = await response.Content.ReadAsStringAsync();
                return serviceUrl;
            }
        }
    }
}
