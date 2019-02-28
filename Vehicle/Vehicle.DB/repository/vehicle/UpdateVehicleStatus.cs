using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicle.DB.repository.vehicle
{
    public class UpdateVehicleStatus
    {
        private readonly AppDbContext _context;
        private readonly Models.Vehicle _vehicle;

        public UpdateVehicleStatus(AppDbContext context, Models.Vehicle vehicle)
        {
            _context = context;
            _vehicle = vehicle;
        }

        public bool Execute()
        {
            
            var item = _context.Vehicle.FirstOrDefault(v => v.VIN == _vehicle.VIN);
            item.VehicleStatus = _vehicle.VehicleStatus;
            _context.SaveChanges();
            return true;
        }
    }
}
