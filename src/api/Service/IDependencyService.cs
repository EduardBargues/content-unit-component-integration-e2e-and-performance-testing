using System.Net;
using System.Threading.Tasks;

namespace Service
{
    public interface IDependencyService
    {
        Task<HttpStatusCode> DoAsync(string url);
    }
}
