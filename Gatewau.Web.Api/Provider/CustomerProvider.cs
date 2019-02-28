using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using model = Vehicle.Models;

namespace Gateway.Web.Api.Provider
{
    public class CustomerProvider: ICustomerProvider
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerProvider(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public List<model.Customer> GetAll()
        {
            var client = this.CientPrepare();
            var response = client.GetAsync(Constants.Constants.Customer.Api.GetAll).Result;
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsAsync<List<model.Customer>>().Result;
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
