using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle.DB.repository.status
{
    public class AddStatus
    {
        private readonly AppDbContext _context;
        private readonly Models.Status _status;

        public AddStatus(AppDbContext context, Models.Status status)
        {
            _context = context;
            _status = status;
        }

        public void Execute()
        {
            _context.Status.Add(_status);
            _context.SaveChanges();
        }
    }
}
