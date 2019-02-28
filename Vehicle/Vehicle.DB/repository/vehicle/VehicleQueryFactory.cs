using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehicle.DB.repository.vehicle;

namespace Vehicle.DB.repository
{
    public class VehicleQueryFactory: IVehicleQueryFactory
    {
        private readonly AppDbContext _context;

        public VehicleQueryFactory(AppDbContext context)
        {
            _context = context;
        }

        public Models.Vehicle GetVehicleById(Int64 id)
        {
            return new GetVehicleById(_context, id).Execute();
        }

        public IQueryable<Models.Vehicle> GetAllVehicls()
        {
            return new GetAllVehicls(_context).Execute();
        }

        public IQueryable<Models.Vehicle> GetVehicleByStatusId(Int32 id)
        {
            return new GetVehicleByStatusId(_context, id).Execute();
        }

        public IQueryable<Models.Vehicle> GetVehicleByCustomerId(Int64 id)
        {
            return new GetVehicleByCustomerId(_context, id).Execute();
        }

        public bool UpdateVehicleStatus(Models.Vehicle vehicle)
        {
            return new UpdateVehicleStatus(_context, vehicle).Execute();
        }

        public IQueryable<Models.Vehicle> GetVehicleByStatusAndCustomerId(Int32 statusId, Int64 customerId)
        {
            return new GetVehicleByStatusAndCustomerId(_context, statusId, customerId).Execute();
        }
    }
}
