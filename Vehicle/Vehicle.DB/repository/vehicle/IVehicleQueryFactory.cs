using System;
using System.Linq;

namespace Vehicle.DB.repository
{
    public interface IVehicleQueryFactory
    {
        Models.Vehicle GetVehicleById(Int64 id);
        IQueryable<Models.Vehicle> GetAllVehicls();
        IQueryable<Models.Vehicle> GetVehicleByStatusId(Int32 id);
        IQueryable<Models.Vehicle> GetVehicleByCustomerId(Int64 id);
        bool UpdateVehicleStatus(Models.Vehicle vehicle);
        IQueryable<Models.Vehicle> GetVehicleByStatusAndCustomerId(Int32 statusId, Int64 customerId);
    }
}