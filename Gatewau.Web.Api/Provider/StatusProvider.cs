using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using model = Vehicle.Models;

namespace Gateway.Web.Api.Provider
{
    public class StatusProvider: IStatusProvider
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatusProvider(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public List<model.Status> GetAll()
        {
            var client = this.CientPrepare();
            var response = client.GetAsync(Constants.Constants.Status.Api.GetAll).Result;
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsAsync<List<model.Status>>().Result;
                return dataObjects;
            }

            return null;
        }

        private HttpClient CientPrepare()
        {
            var client = _httpClientFactory.CreateClient(Constants.Constants.HttpService.HttpServiceUrl);

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(Constants.Constants.HttpService.MediaType));
            return client;
        }
    }
}
