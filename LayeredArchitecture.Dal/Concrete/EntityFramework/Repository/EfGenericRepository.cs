using LayeredArchitecture.Dal.Abstract;
using LayeredArchitecture.Dal.Concrete.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredArchitecture.Dal.Concrete.EntityFramework.Repository
{
    public abstract class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {
        public NorthwindContext northwindContext;

        public T Add(T entity)
        {
            northwindContext.Set<T>().Add(entity);
            northwindContext.SaveChanges();
            return entity;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool dispose)
        {
            if (dispose)
            {
                northwindContext.Dispose();
            }
        }

        public T Get(int id)
        {
            var entity = northwindContext.Set<T>().Find(id);
            northwindContext.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            northwindContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity;
        }

        public List<T> GetAll()
        {
            return northwindContext.Set<T>().AsNoTracking().ToList();
        }

        public List<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return northwindContext.Set<T>().AsNoTracking().Where(predicate).ToList();
        }

        public bool Remove(T entity)
        {
            northwindContext.Set<T>().Remove(entity);
            return northwindContext.SaveChanges() >0;
        }

        public bool Remove(int id)
        {
            return Remove(Get(id));
        }

        public T Update(T entity)
        {
            northwindContext.Set<T>().AddOrUpdate(entity);
            northwindContext.SaveChanges();
            return entity;
        }


    }
}
