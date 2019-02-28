using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicle.DB.repository.status
{
    public class GetStatusByName
    {
        private readonly AppDbContext _context;
        private readonly string _name;

        public GetStatusByName(AppDbContext context, string name)
        {
            _context = context;
            _name = name;
        }

        public Models.Status Execute()
        {
            return _context.Status.FirstOrDefault(s => s.Name.ToLower().Equals(_name.ToLower()));
        } 
    }
}
