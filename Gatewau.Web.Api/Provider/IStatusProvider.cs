using System.Collections.Generic;
using model = Vehicle.Models;

namespace Gateway.Web.Api.Provider
{
    public interface IStatusProvider
    {
        List<model.Status> GetAll();
    }
}