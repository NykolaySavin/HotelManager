using HotelManager.Model.OrderDirectory;
using HotelManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model.Services
{
    public class ServiceTypeService : GenericService<ServiceType>
    {
        DbContext context;
        public ServiceTypeService(DbContext context):base(context)
        {
            this.context = context;
        }
        public override ObservableCollection<ServiceType> GetObservable()
        {
            IEnumerable<ServiceType> rooms = base.GetWithInclude(x => x.Services);
            ObservableCollection<ServiceType> collection = new ObservableCollection<ServiceType>();
            foreach (var item in rooms)
            {
                collection.Add(item);
            }
            return collection;
        }
        public override void Update(ServiceType item)
        {
            if (item != null)
            {


                var existingServiceType = context.Set<ServiceType>().Include(x => x.Services)
               .Where(s => s.Id == item.Id).FirstOrDefault<ServiceType>();
                var deletedServices = existingServiceType.Services.Except(item.Services, (x, y) => x.Id == y.Id).ToList();
                var addedServices = item.Services.Except(existingServiceType.Services, (x, y) => x.Id == y.Id).ToList();
                foreach (Service s in deletedServices)
                {
                    existingServiceType.Services.Remove(s);
                }
                foreach (Service s in addedServices)
                {
                    if (context.Entry(s).State == EntityState.Detached)
                        context.Set<Service>().Attach(s);

                    //7- Add course in existing student's course collection
                    existingServiceType.Services.Add(s);
                }
                // context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
                // context.Entry(s).State = EntityState.Modified;

            }
            //base.Update(item);
        }
    }
}
