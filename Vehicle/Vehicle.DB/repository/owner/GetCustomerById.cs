using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicle.DB.repository.Customer
{
    public class GetCustomerById
    {
        private readonly AppDbContext _context;
        private readonly Int64 _id;

        public GetCustomerById(AppDbContext context, Int64 id)
        {
            _context = context;
            _id = id;
        }

        public Models.Customer Execute()
        {
            return _context.Customer.FirstOrDefault(o => o.Id == _id);
        }
    }
}
