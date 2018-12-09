using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model.Services
{
    public interface IService<T>
    {
        void Add(T item);
        void Edit(T item );
        void Delete(T item);
        List<T> GetItems();
        void Save();
    }
}
