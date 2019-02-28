using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicle.DB.repository.status
{
    public class GetStatuses
    {
        private readonly AppDbContext _context;

        public GetStatuses(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Models.Status> Execute()
        {
            return _context.Status.Where(s => s != null);
        } 

    }
}
