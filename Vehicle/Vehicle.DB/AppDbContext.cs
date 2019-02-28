using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using model = Vehicle.Models;

namespace Vehicle.DB
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<model.Status> Status { get; set; }
        public DbSet<model.Customer> Customer { get; set; }
        public DbSet<model.Vehicle> Vehicle{ get; set; }
    }
}
