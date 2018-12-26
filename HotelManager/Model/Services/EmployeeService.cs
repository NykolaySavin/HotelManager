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
            context.Entry(item.Service).State = EntityState.Unchanged;
            InternalUserData internalUserData = new InternalUserData(item.Username, item.Email, item.Phone, item.Role);
            base.Create(item);
            context.Set<InternalUserData>().Add(internalUserData);
            context.Entry(internalUserData).State = EntityState.Added;

            context.SaveChanges();
        }
        public override void Remove(Employee item)
        {
            context.Entry(item.Service).State = EntityState.Unchanged;
            base.Remove(item);
            
            InternalUserData i = context.Set<InternalUserData>().FirstOrDefault(x=>x.Username==item.Username);
            context.Entry(i).State = EntityState.Deleted;
            context.Set<InternalUserData>().Remove(i);
    

            context.SaveChanges();
        }
        public override void Update(Employee item)
        {
            context.Entry(item.Service).State = EntityState.Unchanged;
            base.Update(item);
        }
        public override ObservableCollection<Employee> GetObservable()
        {
            IEnumerable<Employee> employees = base.GetWithInclude(x => x.Service);
            ObservableCollection<Employee> collection = new ObservableCollection<Employee>();
            foreach (var item in employees)
            {
                collection.Add(item);
            }
            return collection;
        }
    }
}
