using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle.Ping.Simulation
{
    public interface IPingReposnse
    {
        List<Vehicle.Models.Vehicle> CreateResponse();
        void UpdateStatus(List<Vehicle.Models.Vehicle> vehicles);
    }

    public class PingReposnse: IPingReposnse
    {
        private Response _response;
        public PingReposnse()
        {
            _response = new Response();
        }

        public List<Vehicle.Models.Vehicle> CreateResponse()
        {            
            var statuses = _response.GetStatus();
            var customers = _response.GetCustomer();
            var vehicles = _response.GetVehicles(customers, statuses);
            return vehicles;
        }

        public void UpdateStatus(List<Vehicle.Models.Vehicle> vehicles)
        {
            var statuses = _response.GetStatus();
            Random random = new Random();

            foreach (var item in vehicles)
            {
                int randomId = random.Next(0, 2);
                item.VehicleStatus = statuses[randomId];
            }

        }

    }
}
