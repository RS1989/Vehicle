using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle.DB.repository.Customer
{
    public class AddCustomer
    {
        private readonly AppDbContext _context;
        private readonly Models.Customer _customer;

        public AddCustomer(AppDbContext context, Models.Customer customer)
        {
            _context = context;
            _customer = customer;
        }

        public void Execute()
        {
            _context.Customer.Add(_customer);
            _context.SaveChanges();
        }
    }
}
