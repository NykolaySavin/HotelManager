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
        public override IEnumerable<ServiceType> Get()
        {
            IEnumerable<ServiceType> serviceTypes = base.GetWithInclude(x => x.Services);
            return serviceTypes;
        }
        ////public override void Update(ServiceType item)
        ////{
        ////    if (item != null)
        ////    {


        ////        var existingServiceType = context.Set<ServiceType>().Include(x => x.Services)
        ////       .Where(s => s.Id == item.Id).FirstOrDefault<ServiceType>();
        ////        var deletedServices = existingServiceType.Services.Except(item.Services, (x, y) => x.Id == y.Id).ToList();
        ////        var addedServices = item.Services.Except(existingServiceType.Services, (x, y) => x.Id == y.Id).ToList();
        ////        foreach (Service s in deletedServices)
        ////        {
        ////            existingServiceType.Services.Remove(s);
        ////        }
        ////        foreach (Service s in addedServices)
        ////        {
        ////            if (context.Entry(s).State == EntityState.Detached)
        ////                context.Set<Service>().Attach(s);
        ////            existingServiceType.Services.Add(s);
        ////        }
        ////        context.SaveChanges();

        ////    }
        ////}
    }
}
