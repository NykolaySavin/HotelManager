using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model.Context
{
    public class UserDataContext : DbContext
    {
        public UserDataContext() : base("DbConnection")
        { }
        public DbSet<InternalUserData> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }

}
