using System;
using System.Linq;

namespace Vehicle.DB.repository
{
    public interface ICustomerQueryFactory
    {
        void AddCustomer(Models.Customer customer);
        IQueryable<Models.Customer> GetCustomersByAddress(string address);
        IQueryable<Models.Customer> GetCustomers();
        IQueryable<Models.Customer> GetCustomerByFirstName(string firstName);
        IQueryable<Models.Customer> GetCustomersBySecondName(string secondName);
        Models.Customer GetCustomersById(Int64 id);
    }
}