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
    public class FurnitureService : IService<Furniture>
    {
        public void Add(Furniture item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Furniture item)
        {
            throw new NotImplementedException();
        }

        public void Edit(Furniture item)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Furniture> GetItems()
        {
            ObservableCollection<Furniture> furniture = new ObservableCollection<Furniture>();
            using (HotelContext context = new HotelContext())
            {
                foreach (var item in context.Furnitures)
                {
                    furniture.Add(item);
                }
            }
            return furniture;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
