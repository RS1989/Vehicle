using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehicle.DB.repository.status;

namespace Vehicle.DB.repository
{
    public class StatusQueryFactory: IStatusQueryFactory
    {
        private readonly AppDbContext _context;

        public StatusQueryFactory(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Models.Status> GetStatuses()
        {
            return new GetStatuses(_context).Execute();
        }

        public Models.Status GetStatusByID(Int32 id)
        {
            return new GetStatusById(_context, id).Execute();
        }

        public Models.Status GetStatusByName(string name)
        {
            return new GetStatusByName(_context, name).Execute();
        }

        public void AddStatus(Models.Status status)
        {
            new AddStatus(_context, status).Execute();
        }
    }
}
