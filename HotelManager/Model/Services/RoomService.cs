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
    public class RoomService : IService<Room>
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
            using (HotelContext context = new HotelContext())
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Edit(Room item)
        {
            using (HotelContext context = new HotelContext())
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public ObservableCollection<Room> GetItems()
        {
            ObservableCollection<Room> rooms = new ObservableCollection<Room>();
            using (HotelContext context =new HotelContext())
            {
                foreach (var item in context.Rooms.Include(i=>i.Furniture))
                {
                    rooms.Add(item);
                }               
            }
            return rooms;
        }
    }
    public interface IRoomService : IService<Room>
    {

    }
}
