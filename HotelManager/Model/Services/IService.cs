using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model.Services
{
    public interface IService<T>
    {
        void Add(T item);
        void Edit(T item, int id );
        void Delete(T item);
        List<T> GetItems();
        void Save();
    }
}
