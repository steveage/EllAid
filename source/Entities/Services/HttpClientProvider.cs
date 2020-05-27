using System.Net.Http;
using System.Threading.Tasks;

namespace EllAid.Entities.Services
{
    public class HttpClientProvider : IHttpClientProvider
    {
        private readonly HttpClient client;

        public HttpClientProvider(HttpClient client) => this.client = client;

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage) => await client.SendAsync(requestMessage);
    }
}