using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicle.DB.repository.Customer
{
    public class GetAllCustomers
    {
        private readonly AppDbContext _context;

        public GetAllCustomers(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Models.Customer> Execute()
        {
            return _context.Customer.Where(o => o != null);
        }
    }
}
