using System;
using System.Net.Http;
using System.Threading.Tasks;
using EllAid.Entities;
using EllAid.Entities.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace EllAid.UseCases.Dashboard.Identity
{
    class IdentityProvider : IIdentityProvider
    {
        readonly IHttpClientProvider provider;
        readonly IConfiguration config;

        public IdentityProvider(IHttpClientProvider provider, IConfiguration config)
        {
            this.provider = provider;
            this.config = config;
        }

        public async Task<UserSignInResult> CheckSignInAsync(string userName, string password)
        {
            string serviceUri = $"{config["Services:DataSource:Uri"]}{config["Services:DataSource:CheckSignInPath"]}";
            UriBuilder builder = new UriBuilder(serviceUri);
            builder.Query = $"userName={userName}&password={password}";
            HttpRequestMessage request = new HttpRequestMessage(   HttpMethod.Get, builder.Uri);
            HttpResponseMessage response = await provider.SendAsync(request);
            if(response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                UserSignInResult content = JsonConvert.DeserializeObject<UserSignInResult>($"'{res}'");
                return content;
            }
            else
            {
                return UserSignInResult.Failed;
            }
        }
    }
}