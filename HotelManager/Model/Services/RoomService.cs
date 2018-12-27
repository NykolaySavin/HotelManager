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
    public class RoomService : GenericService<Room>
    {
        public RoomService(DbContext context) : base(context)
        {

        }
        public override IEnumerable<Room> Get()
        {
            IEnumerable<Room> rooms = base.GetWithInclude(x => x.Furniture);
            return rooms;
        }
    }
}
