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

        public virtual IEnumerable<T> Get()
        {
            return _dbSet.ToList();
        }
        public virtual IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }
        public virtual T FindById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Create(T item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }
        public virtual void Update(T item)
        {
                _context.SaveChanges();
        }
        public virtual void Remove(T item)
        {
                _context.Entry(item).State = EntityState.Deleted;
                _dbSet.Remove(item);
                _context.SaveChanges();
        }
        protected IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        protected IEnumerable<T> GetWithInclude(Func<T, bool> predicate,
            params Expression<Func<T, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        private IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
