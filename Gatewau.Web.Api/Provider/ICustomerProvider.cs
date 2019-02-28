using System.Collections.Generic;
using model = Vehicle.Models;

namespace Gateway.Web.Api.Provider
{
    public interface ICustomerProvider
    {
        List<model.Customer> GetAll();
    }
}