using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehicle.DB.repository.Customer;

namespace Vehicle.DB.repository
{
    public class CustomerQueryFactory : ICustomerQueryFactory
    {
        private readonly AppDbContext _context;

        public CustomerQueryFactory(AppDbContext context)
        {
            _context = context;
        }

        public void AddCustomer(Models.Customer customer)
        {
            new AddCustomer(_context, customer).Execute();
        }

        public IQueryable<Models.Customer> GetCustomersByAddress(string address)
        {
            return new GetCustomersByAdress(_context, address).Execute();
        }

        public IQueryable<Models.Customer> GetCustomers()
        {
            return new GetAllCustomers(_context).Execute();
        }

        public IQueryable<Models.Customer> GetCustomerByFirstName(string firstName)
        {
            return new GetCustomerByFirstName(_context, firstName).Execute();
        }

        public IQueryable<Models.Customer> GetCustomersBySecondName(string secondName)
        {
            return new GetCustomerBySecondName(_context, secondName).Execute();
        }

        public Models.Customer GetCustomersById(Int64 id)
        {
            return new GetCustomerById(_context, id).Execute();
        }

    }
}
