using HotelManager.Model.Context;
using HotelManager.Model.OrderDirectory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model.Services
{
    public class RoomService : IRoomService
    {
        public void Add(Room item)
        {
            using (HotelContext context = new HotelContext())
            {
                context.Rooms.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(Room item)
        {
            
        }

        public void Edit(Room item)
        {
            using (HotelContext context = new HotelContext())
            {
                Room old = context.Rooms.SingleOrDefault(x=>x.Id==item.Id);
                old.Number = item.Number;
                old.State = item.State;
                old.Furniture.AddRange(item.Furniture);
                context.SaveChanges();
            }
        }

        public List<Room> GetItems()
        {
            List<Room> rooms = new List<Room>();
            using (HotelContext context =new HotelContext())
            {
                rooms.AddRange(context.Rooms.ToList());               
            }
            return rooms;
        }

        public void Save()
        {
            
        }
    }
    public interface IRoomService : IService<Room>
    {

    }
}
