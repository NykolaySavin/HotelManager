using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model.Services
{
    public class EmployeeService : GenericService<Employee>
    {
        DbContext context;
        public EmployeeService(DbContext context) : base(context)
        {
            this.context = context;
        }
        public override void Create(Employee item)
        {
            //context.Entry(item.Service).State = EntityState.Unchanged;
           
            base.Create(item);
            InternalUserData internalUserData = new InternalUserData(item.Username, item.Email, item.Phone, item.Role) { Employee = item };
            context.Set<InternalUserData>().Add(internalUserData);
            context.Entry(internalUserData).State = EntityState.Added;

            context.SaveChanges();
        }
        public override void Remove(Employee item)
        {
            InternalUserData i = context.Set<InternalUserData>().FirstOrDefault(x => x.Username == item.Username);
            context.Entry(i).State = EntityState.Deleted;
            context.Set<InternalUserData>().Remove(i);
            //context.Entry(item.Service).State = EntityState.Unchanged;
            base.Remove(item);
            
           
            context.SaveChanges();
        }
    }
}
