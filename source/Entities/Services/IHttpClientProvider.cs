using System.Net.Http;
using System.Threading.Tasks;

namespace EllAid.Entities.Services
{
    public interface IHttpClientProvider
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage);
    }
}