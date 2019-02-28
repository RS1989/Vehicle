using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Web.Api.Constants
{
    public static partial class Constants
    {
        public static class Vehicle
        {
            public static class Api
            {
                public static string BaseApiUrl = "/api/VehicleDB/";
                public static string GetAll = "/api/VehicleDB/vehicles";
                public static string GetByStatusId = "vehicles/status/";
                public static string GetByCustomerId = "vehicles/customer/";

                public static string FiltrBaseCustomer = "customer/";
                public static string FiltrBaseStatus = "status/";

            }
        }
    }
}
