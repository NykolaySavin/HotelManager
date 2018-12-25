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
        void Create(T item);
        T FindById(int id);
        IEnumerable<T> Get();
        ObservableCollection<T> GetObservable();
        IEnumerable<T> Get(Func<T, bool> predicate);
        void Remove(T item);
        void Update(T item);
    }
}
