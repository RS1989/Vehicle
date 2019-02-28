using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.DB.repository;

namespace Vehicle.DB.Api.Provider
{
    public class CustomerProvider: ICustomerProvider
    {
        private readonly ICustomerQueryFactory _customerQueryFactory;

        public CustomerProvider(ICustomerQueryFactory customerQueryFactory)
        {
            _customerQueryFactory = customerQueryFactory;
        }

        public IQueryable<Models.Customer> GetAll()
        {
            return _customerQueryFactory.GetCustomers();
        }

        public Models.Customer GetByID(Int64 id)
        {
            return _customerQueryFactory.GetCustomersById(id);
        }
    }
}
