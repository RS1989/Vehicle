using System;
using System.Linq;

namespace Vehicle.DB.repository
{
    public interface IStatusQueryFactory
    {
        IQueryable<Models.Status> GetStatuses();
        Models.Status GetStatusByID(Int32 id);
        Models.Status GetStatusByName(string name);
        void AddStatus(Models.Status status);
    }
}