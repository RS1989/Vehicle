using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicle.DB.repository.vehicle
{
    public class GetVehicleByStatusId
    {
        private readonly AppDbContext _context;
        private readonly Int32 _statusId;

        public GetVehicleByStatusId(AppDbContext context, Int32 statusId)
        {
            _context = context;
            _statusId = statusId;
        }

        public IQueryable<Models.Vehicle> Execute()
        {
            return _context.Vehicle.Where(v => v.VehicleStatus.Id == _statusId);
        }
    }
}
