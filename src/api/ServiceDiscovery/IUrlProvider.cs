using System;
using System.Threading.Tasks;

namespace ServiceDiscovery
{
    public interface IUrlProvider
    {
        Task<string> GetUrlAsync(string serviceName);
    }
}
