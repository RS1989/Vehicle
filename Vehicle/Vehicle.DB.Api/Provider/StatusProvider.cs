using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.DB.repository;

namespace Vehicle.DB.Api.Provider
{
    public class StatusProvider: IStatusProvider
    {
        private readonly IStatusQueryFactory _statusQueryFactory;
        public StatusProvider(IStatusQueryFactory statusQueryFactory)
        {
            _statusQueryFactory = statusQueryFactory;
        }

        public List<Models.Status> GetAll()
        {
            return _statusQueryFactory.GetStatuses().ToList();
        }

        public Models.Status GetById(Int32 id)
        {
            return _statusQueryFactory.GetStatusByID(id);
        }

        public Models.Status GetByName(string name)
        {
            return _statusQueryFactory.GetStatusByName(name);
        }

    }
}
