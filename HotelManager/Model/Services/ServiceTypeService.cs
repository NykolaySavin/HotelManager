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
    }
}
