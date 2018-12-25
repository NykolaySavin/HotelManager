using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model.Services
{
    public interface IService<T> where T:class
    {
        void Add(T item);
        void Edit(T item );
        void Delete(T item);
        ObservableCollection<T> Get();
    }
}
