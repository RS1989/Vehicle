using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicle.DB.repository.status
{
    public class GetStatusById
    {
        private readonly AppDbContext _context;
        private readonly Int32 _id;

        public GetStatusById(AppDbContext context, Int32 id)
        {
            _context = context;
            _id = id;
        }

        public Models.Status Execute()
        {
            return _context.Status.FirstOrDefault(s=> s.Id == _id);
        }

    }
}
