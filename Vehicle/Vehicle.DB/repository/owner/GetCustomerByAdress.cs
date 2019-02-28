using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicle.DB.repository.Customer
{
    public class GetCustomersByAdress
    {
        private readonly AppDbContext _context;
        private readonly string _address;

        public GetCustomersByAdress(AppDbContext context, string address)
        {
            _context = context;
            _address = address;
        }

        public IQueryable<Models.Customer> Execute()
        {
            return _context.Customer.Where(o => o.Address.ToLower().Equals(_address.ToLower()));
        }
    }
}
