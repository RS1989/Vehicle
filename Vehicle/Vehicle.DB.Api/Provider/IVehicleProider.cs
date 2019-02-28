using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicle.DB.Api.Provider
{
    public interface IVehicleProider
    {
        List<Models.Vehicle> GetAll();
        List<Models.Vehicle> GetByStatusId(Int32 id);
        List<Models.Vehicle> GetByCustomerId(Int64 id);
        bool UpdateVehicleStatus(Models.Vehicle vehicle);
        List<Models.Vehicle> GetVehicleByStatusAndCustomerId(Int32 statusId, Int64 customerId);
    }
}