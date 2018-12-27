using HotelManager.Model.OrderDirectory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model.Services
{
    class ServiceService : GenericService<Service>
    {
        DbContext context;
        public ServiceService(DbContext context) : base(context)
        {
            this.context = context;
        }
        public override IEnumerable<Service> Get()
        {
            return base.GetWithInclude(x => x.ServiceTypes, x => x.Employees);
        }
    }
}
