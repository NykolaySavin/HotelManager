using HotelManager.Model.OrderDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model.Services
{
    public class RoomService : IRoomService
    {
        public void Add(Room item)
        {
          
        }

        public void Delete(Room item)
        {
            
        }

        public void Edit(Room item, int id)
        {
           
        }

        public List<Room> GetItems()
        {

        }
    }
    public interface IRoomService : IService<Room>
    {

    }
}
