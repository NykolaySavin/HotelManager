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
                //Room old = context.Rooms.SingleOrDefault(x=>x.Id==item.Id);
                //old.Number = item.Number;
                //old.State = item.State;
                //foreach (var el in item.Furniture)
                //{
                //    old.Furniture.Add(el);
                //}
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<Room> GetItems()
        {
            List<Room> rooms = new List<Room>();
            using (HotelContext context =new HotelContext())
            {
                foreach (var item in context.Rooms.Include(i=>i.Furniture))
                {
                    rooms.Add(item);
                }               
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
