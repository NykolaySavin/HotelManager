using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model.Services
{
    public class GenericService<T> :IService<T> where T :Base
    {
        DbContext _context;
        DbSet<T> _dbSet;

        public GenericService(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }
        public virtual ObservableCollection<T> GetObservable()
        {
            List<T> ts= _dbSet.AsNoTracking().ToList();
            ObservableCollection<T> collection = new ObservableCollection<T>();
            foreach (var item in ts)
            {
                collection.Add(item);
            }
            return collection;
        }
        public virtual ObservableCollection<T> GetObservable(Func<T, bool> predicate)
        {
            List<T> ts = _dbSet.AsNoTracking().Where(predicate).ToList();
            ObservableCollection<T> collection = new ObservableCollection<T>();
            foreach (var item in ts)
            {
                collection.Add(item);
            }
            return collection;
        }
        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }
        public T FindById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Create(T item)
        {
            _dbSet.Add(item);
            _context.Entry(item).State = EntityState.Added;

            _context.SaveChanges();
        }
        public virtual void Update(T item)
        {
            T i = _dbSet.Where(x => x.Id == item.Id).FirstOrDefault();
            if (i != null)
            {
                _context.Entry(i).State = EntityState.Modified;
            _context.SaveChanges();
            }
            else
            {
                throw new Exception("There are not such item in database");
            }
        }
        public virtual void Remove(T item)
        {
            T i = _dbSet.Where(x => x.Id == item.Id).FirstOrDefault();
            if (i!=null)
            {
                _context.Entry(i).State = EntityState.Deleted;
                _dbSet.Remove(i);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("There are not such item in database");
            }
            
        }
        public IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<T> GetWithInclude(Func<T, bool> predicate,
            params Expression<Func<T, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        private IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
