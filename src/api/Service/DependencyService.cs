using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Service
{
    public class DependencyService : IDependencyService
    {
        private readonly ILogger<DependencyService> _logger;

        public DependencyService(ILogger<DependencyService> logger)
        {
            _logger = logger;
        }
        public async Task<HttpStatusCode> DoAsync(string url)
        {
            var fullUrl = $"{url}/dependency";
            _logger.LogWarning($"calling dependency on url {fullUrl} ...");
            using (HttpClient client = new HttpClient())
            using (var response = await client.PostAsync(fullUrl, null))
            {
                _logger.LogWarning($"dependency responded with {response.StatusCode}");
                return response.StatusCode;
            }
        }

        public async Task<int> GetNumberOfCallsAsync(string url)
        {
            var fullUrl = $"{url}/calls";
            _logger.LogWarning($"calling dependency on url {fullUrl} ...");
            using (HttpClient client = new HttpClient())
            using (var response = await client.GetAsync(fullUrl))
            {
                _logger.LogWarning($"dependency responded with {response.StatusCode}");
                var body = await response.Content.ReadAsStringAsync();
                var calls = JsonConvert.DeserializeObject<Call[]>(body);
                return calls.Length;
            }
        }
    }
}
