using System;
using System.Collections.Generic;
using System.Text;
using Vehicle.Models;

namespace Vehicle.Ping.Simulation
{
    public interface IResponse
    {
        List<Status> GetStatus();
        List<Customer> GetCustomer();
        List<Vehicle.Models.Vehicle> GetVehicles(List<Customer> customer, List<Status> status);
    }

    public class Response: IResponse
    {
        public Response()
        {
        }

        public List<Status> GetStatus()
        {
            var result = new List<Status>();

            var statusCon = new Status();
            statusCon.Id = 1;
            statusCon.Name = @"connected";
            result.Add(statusCon);

            var statusDisCon = new Status();
            statusDisCon.Id = 2;
            statusDisCon.Name = @"disconnected";           
            result.Add(statusDisCon);

            return result;
        }

        public List<Customer> GetCustomer()
        {
            var result = new List<Customer>();

            var customer1 = new Customer();
            customer1.Id = 1;
            customer1.FirstName = @"Kalles";
            customer1.SecondName = @"Grustransporter";
            customer1.Address = @"Cementvägen 8, 111 11 Södertälje";
            result.Add(customer1);

            var customer2 = new Customer();
            customer2.Id = 2;
            customer2.FirstName = @"Johans";
            customer2.SecondName = @"Bulk";
            customer2.Address = @"Balkvägen 12, 222 22 Stockholm";
            result.Add(customer2);

            var customer3 = new Customer();
            customer3.Id = 3;
            customer3.FirstName = @"Haralds";
            customer3.SecondName = @"Värdetransporter";
            customer3.Address = @"Budgetvägen 1, 333 33 Uppsala";
            result.Add(customer3);

            return result;
        }

        public List<Vehicle.Models.Vehicle> GetVehicles(List<Customer> customer, List<Status> status)
        {
            var result = new List<Vehicle.Models.Vehicle>();

            var vehicle1 = new Vehicle.Models.Vehicle();
            vehicle1.Id = 1;
            vehicle1.RegNumber = "ABC123";
            vehicle1.VIN = "YS2R4X20005399401";
            vehicle1.VehicleCustomer = customer[0];
            vehicle1.VehicleStatus = status[0];
            result.Add(vehicle1);

            var vehicle2 = new Vehicle.Models.Vehicle();
            vehicle2.Id = 2;
            vehicle2.RegNumber = "DEF456";
            vehicle2.VIN = "VLUR4X20009093588";
            vehicle2.VehicleCustomer = customer[0];
            vehicle2.VehicleStatus = status[0];
            result.Add(vehicle2);

            var vehicle3 = new Vehicle.Models.Vehicle();
            vehicle3.Id = 3;
            vehicle3.RegNumber = "GHI789";
            vehicle3.VIN = "VLUR4X20009048066";
            vehicle3.VehicleCustomer = customer[0];
            vehicle3.VehicleStatus = status[0];
            result.Add(vehicle3);

            var vehicle4 = new Vehicle.Models.Vehicle();
            vehicle4.Id = 4;
            vehicle4.RegNumber = "JKL012";
            vehicle4.VIN = "YS2R4X20005388011";
            vehicle4.VehicleCustomer = customer[1];
            vehicle4.VehicleStatus = status[0];
            result.Add(vehicle4);

            var vehicle5 = new Vehicle.Models.Vehicle();
            vehicle5.Id = 5;
            vehicle5.RegNumber = "MNO345";
            vehicle5.VIN = "YS2R4X20005387949";
            vehicle5.VehicleCustomer = customer[1];
            vehicle5.VehicleStatus = status[0];
            result.Add(vehicle5);

            var vehicle6 = new Vehicle.Models.Vehicle();
            vehicle6.Id = 6;
            vehicle6.RegNumber = "PQR678";
            vehicle6.VIN = "VLUR4X20009048066";
            vehicle6.VehicleCustomer = customer[2];
            vehicle6.VehicleStatus = status[0];
            result.Add(vehicle6);

            var vehicle7 = new Vehicle.Models.Vehicle();
            vehicle7.Id = 7;
            vehicle7.RegNumber = "STU901";
            vehicle7.VIN = "YS2R4X20005387055";
            vehicle7.VehicleCustomer = customer[2];
            vehicle7.VehicleStatus = status[0];
            result.Add(vehicle7);

            return result;
        }
    }
}
