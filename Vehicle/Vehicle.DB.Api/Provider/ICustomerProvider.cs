using System;
using System.Linq;

namespace Vehicle.DB.Api.Provider
{
    public interface ICustomerProvider
    {
        IQueryable<Models.Customer> GetAll();
        Models.Customer GetByID(Int64 id);
    }
}