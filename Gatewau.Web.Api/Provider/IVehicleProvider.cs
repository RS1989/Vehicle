using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using model = Vehicle.Models;

namespace Gateway.Web.Api.Provider
{
    public interface IVehicleProvider
    {
        List<model.Vehicle> GetAll();
        List<model.Vehicle> GetByStatusId(Int32 id);
        List<model.Vehicle> GetByCustomerId(Int64 id);
        List<model.Vehicle> GetVehicleByStatusAndCustomerId(Int32 statusId, Int64 customerId);
    }
}
