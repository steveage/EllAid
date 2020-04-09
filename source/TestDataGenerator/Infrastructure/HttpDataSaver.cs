using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.UseCases.Adapters;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace EllAid.TestDataGenerator.Infrastructure
{
    class HttpDataSaver : IDataSaver
    {
        readonly HttpClient client;
        readonly string dataStoreUri;
        internal const string dataStoreServiceUriConfigKey = "dataStoreServiceUri";

        public HttpDataSaver(HttpClient client, IConfiguration config)
        {
            this.client = client;
            dataStoreUri = config[dataStoreServiceUriConfigKey];
        }

        public async Task SaveAssistantsAsync(List<Assistant> assistants) => await SendPutRequestAsync<List<Assistant>>(assistants);

        public async Task SaveEllCoachesAsync(List<EllCoach> ellCoaches) => await SendPutRequestAsync<List<EllCoach>>(ellCoaches);

        public async Task SaveInstructorsAsync(List<Instructor> instructors) => await SendPutRequestAsync<List<Instructor>>(instructors);

        private async Task SendPutRequestAsync<T>(T item) where T : class
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, dataStoreUri);
            string json = JsonConvert.SerializeObject(item);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.SendAsync(request);
        }
    }
}