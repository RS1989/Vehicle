using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicle.DB.repository.Customer
{
    public class GetCustomerByFirstName
    {
        private readonly AppDbContext _context;
        private readonly string _name;

        public GetCustomerByFirstName(AppDbContext context, string name)
        {
            _context = context;
            _name = name;
        }

        public IQueryable<Models.Customer> Execute()
        {
            return _context.Customer.Where(o => o.FirstName.ToLower().Equals(_name.ToLower()));
        }
    }
}
