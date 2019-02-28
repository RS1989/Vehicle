using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicle.DB.repository.vehicle
{
    public class GetVehicleById
    {
        private readonly AppDbContext _context;
        private readonly Int64 _id;

        public GetVehicleById(AppDbContext context, Int64 id)
        {
            _context = context;
            _id = id;
        }

        public Models.Vehicle Execute()
        {
            return _context.Vehicle.FirstOrDefault(v=> v.Id == _id);
        }
    }
}
