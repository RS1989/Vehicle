using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vehicle.Ping.Simulation;

namespace Vehicle.Ping.Ping
{
    public interface IPing
    {
        void PingExecute();
    }
    public class Ping : IPing
    {
        private readonly Int32 _updateTicker;
        private Int32 _repeat;
        private readonly PingReposnse _response;
        private readonly string _serviceUrl;
        private readonly string _endpoint;

        public Ping(Int32 updateTicker, string serviceUrl, string endpoint)
        {
            _updateTicker = updateTicker;
            _serviceUrl = serviceUrl;
            _endpoint = endpoint;
            _response = new Simulation.PingReposnse();
        }

        public void PingExecute()
        {
            var vehicles = _response.CreateResponse();

            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(5);


            while (true)
            {
                CallService(vehicles);
                Thread.Sleep(60000);
            }


        }

        private void CallService(List<Vehicle.Models.Vehicle> vehicles)
        {
            if (_repeat == _updateTicker)
            {
                _response.UpdateStatus(vehicles);
            }

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue(Constants.Constants.ConfigSection.MediaType));

            client.BaseAddress = new Uri(_serviceUrl);

            var data = JsonConvert.SerializeObject(vehicles);

            var content = new StringContent(data);

            HttpResponseMessage response = client.PostAsync(_endpoint, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsStringAsync().Result;
            }
            _repeat++;
        }
    }
}
