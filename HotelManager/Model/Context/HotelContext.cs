using HotelManager.Model.OrderDirectory;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model.Context
{
    public class HotelContext : DbContext
    {

        public HotelContext() : base("DbConnection")
        { }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<InternalUserData> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
