using HotelManager.Model.Context;
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
    public class FurnitureService : GenericService<Furniture>
    {
        DbContext _context;
        
        public FurnitureService(DbContext context) :base(context)
        {
            this._context = context;
        }
        public override IEnumerable<Furniture> Get()
        {
            return base.GetWithInclude(x => x.Room);

        }
    }
}
