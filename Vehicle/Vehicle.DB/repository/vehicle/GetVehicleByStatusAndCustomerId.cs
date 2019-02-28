using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicle.DB.repository.vehicle
{
    public class GetVehicleByStatusAndCustomerId
    {
        private readonly AppDbContext _context;
        private readonly Int32 _statusId;
        public readonly Int64 _customerId;

        public GetVehicleByStatusAndCustomerId(AppDbContext context, Int32 statusId, Int64 customerId)
        {
            _context = context;
            _statusId = statusId;
            _customerId = customerId;
        }

        public IQueryable<Models.Vehicle> Execute()
        {
            return _context.Vehicle.Where(v =>
                (_statusId != 0 && _customerId != 0 && v.VehicleCustomer.Id == _customerId && v.VehicleStatus.Id == _statusId)
                || (_statusId != 0 && _customerId == 0 && v.VehicleStatus.Id == _statusId)
                || (_customerId != 0 && _statusId == 0 && v.VehicleCustomer.Id == _customerId));

        }
    }
}
