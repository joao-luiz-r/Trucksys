using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckSys.Domain.Interfaces.Repository;
using TruckSys.Infra.Data;

namespace TruckSys.Infra.Repository
{
    internal class EFRepository<T> : IRepository<T> where T : class
    {
        protected readonly TruckContext _truckContext;

        public EFRepository(TruckContext truckContext)
        {
            _truckContext = truckContext;
        }

        public virtual T Add(T entity)
        {
            _truckContext.Set<T>().Add(entity);
            _truckContext.SaveChanges();
            return entity;
        }

        public virtual void Update(T entity)
        {
            _truckContext.Entry(entity).State = EntityState.Modified;
            _truckContext.SaveChanges();
        }

        public IEnumerable<T> Search(System.Linq.Expressions.Expression<Func<T, bool>> predicado)
        {
            return _truckContext.Set<T>().Where(predicado).AsEnumerable();
        }

        public T GetById(int id)
        {
            return _truckContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _truckContext.Set<T>().AsEnumerable();
        }

        public void Delete(T entity)
        {
            _truckContext.Set<T>().Remove(entity);
            _truckContext.SaveChanges();
        }

    }
}
