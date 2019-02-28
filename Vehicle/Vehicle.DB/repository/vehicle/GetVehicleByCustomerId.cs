using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicle.DB.repository.vehicle
{
    public class GetVehicleByCustomerId
    {
        private readonly AppDbContext _context;
        private readonly Int64 _ownerId;

        public GetVehicleByCustomerId(AppDbContext context, Int64 ownerId)
        {
            _context = context;
            _ownerId = ownerId;
        }

        public IQueryable<Models.Vehicle> Execute()
        {
            return _context.Vehicle.Where(v => v.VehicleCustomer.Id == _ownerId);
        }
    }
}
