using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EllAid.Entities.Data;
using EllAid.UseCases.Generator;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace EllAid.Details.Main.DataSaver
{
    public class HttpDataSaver : IDataSaver
    {
        readonly HttpClient client;
        readonly string dataStoreUri;
        readonly string createInstructorsUri;
        readonly string createEllCoachesUri;
        readonly string createAssistantsUri;
        readonly string deleteDataStoreUri;
        readonly string createDataStoreUri;
        internal const string serviceUriConfigKey = "dataStoreServiceUri";
        internal const string instructorsApiPathKey = "createInstructorsApiPath";
        internal const string ellCoachesApiPathKey = "createEllCoachesApiPath";
        internal const string assistantsApiPathKey = "createAssistantsApiPath";
        internal const string deleteDataStoreApiPathKey = "deleteDataStoreApiPath";
        internal const string createDataStoreApiPathKey = "createDataStoreApiPath";

        public HttpDataSaver(HttpClient client, IConfiguration config)
        {
            this.client = client;
            dataStoreUri = config[serviceUriConfigKey];
            createInstructorsUri = $"{dataStoreUri}{config[instructorsApiPathKey]}";
            createEllCoachesUri = $"{dataStoreUri}{config[ellCoachesApiPathKey]}";
            createAssistantsUri = $"{dataStoreUri}{config[assistantsApiPathKey]}";
            deleteDataStoreUri = $"{dataStoreUri}{config[deleteDataStoreApiPathKey]}";
            createDataStoreUri = $"{dataStoreUri}{config[createDataStoreApiPathKey]}";
        }

        public async Task SaveAssistantsAsync(List<Assistant> assistants) => await SendPostRequestAsync<List<Assistant>>(assistants, createAssistantsUri);

        public async Task SaveEllCoachesAsync(List<EllCoach> ellCoaches) => await SendPostRequestAsync<List<EllCoach>>(ellCoaches, createEllCoachesUri);

        public async Task SaveInstructorsAsync(List<Instructor> instructors) => await SendPostRequestAsync<List<Instructor>>(instructors, createInstructorsUri);

        private async Task SendPostRequestAsync<T>(T item, string uri) where T : class
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri);
            string json = JsonConvert.SerializeObject(item, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            Debug.Print(json);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await SendRequest(request);
        }

        async Task<HttpResponseMessage> SendRequest(HttpRequestMessage request) => await client.SendAsync(request);

        public async Task DeleteDataStoreAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, deleteDataStoreUri);
            HttpResponseMessage response = await SendRequest(request);
        }

        public async Task CreateDataStoreAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, createDataStoreUri);
            HttpResponseMessage response = await SendRequest(request);
        }
    }
}