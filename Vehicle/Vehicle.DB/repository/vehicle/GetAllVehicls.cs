using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicle.DB.repository.vehicle
{
    public class GetAllVehicls
    {
        private readonly AppDbContext _context;

        public GetAllVehicls(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Models.Vehicle> Execute()
        {
            return _context.Vehicle.Where(v => v != null);
        }
    }
}
