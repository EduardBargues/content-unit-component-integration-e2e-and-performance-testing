using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Service
{
    public class DependencyService : IDependencyService
    {
        public async Task<HttpStatusCode> DoAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            using (var response = await client.GetAsync(url))
            {
                return response.StatusCode;
            }
        }
    }
}
