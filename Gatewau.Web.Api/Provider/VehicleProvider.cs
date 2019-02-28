using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using model = Vehicle.Models;

namespace Gateway.Web.Api.Provider
{
    public class VehicleProvider : IVehicleProvider
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VehicleProvider(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public List<model.Vehicle> GetAll()
        {
            var client = this.CientPrepare();
            return Execute(client, Constants.Constants.Vehicle.Api.GetAll);
        }



        public List<model.Vehicle> GetByStatusId(Int32 id)
        {
            var client = this.CientPrepare();
            var url = $"{Constants.Constants.Vehicle.Api.BaseApiUrl}{Constants.Constants.Vehicle.Api.GetByStatusId}{id}";
            return Execute(client, url);
        }

        public List<model.Vehicle> GetByCustomerId(Int64 id)
        {
            var client = this.CientPrepare();
            var url = $"{Constants.Constants.Vehicle.Api.BaseApiUrl}{Constants.Constants.Vehicle.Api.GetByCustomerId}{id}";
            return Execute(client, url);
        }

        public List<model.Vehicle> GetVehicleByStatusAndCustomerId(Int32 statusId, Int64 customerId)
        {
            var client = this.CientPrepare();
            var url = $"{Constants.Constants.Vehicle.Api.BaseApiUrl}{Constants.Constants.Vehicle.Api.FiltrBaseCustomer}{customerId}{Constants.Constants.Vehicle.Api.FiltrBaseStatus}{statusId}";
            return Execute(client, url);
        }

        private HttpClient CientPrepare()
        {
            var client = _httpClientFactory.CreateClient(Constants.Constants.HttpService.HttpServiceUrl);

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(Constants.Constants.HttpService.MediaType));
            return client;
        }

        private List<model.Vehicle> Execute(HttpClient client, string url)
        {
            var response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsAsync<List<model.Vehicle>>().Result;
                return dataObjects;
            }
            return null;
        }


    }   
}
