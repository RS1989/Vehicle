using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicle.DB.Api.Provider
{
    public interface IStatusProvider
    {
        List<Models.Status> GetAll();
        Models.Status GetById(Int32 id);
        Models.Status GetByName(string name);
    }
}