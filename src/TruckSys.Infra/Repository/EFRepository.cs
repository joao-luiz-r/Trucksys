using Microsoft.EntityFrameworkCore;
using TruckSys.Domain.Interfaces.Repository;
using TruckSys.Infra.Data;

namespace TruckSys.Infra.Repository
{
    public class EFRepository<T> : IEFRepository<T> where T : class
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

        public virtual T Update(T entity)
        {
            _truckContext.Entry(entity).State = EntityState.Modified;
            _truckContext.SaveChanges();
            return entity;
        }

        public T GetById(int id)
        {
            return _truckContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _truckContext.Set<T>().AsEnumerable();
        }

        public void Delete(int id)
        {
            _truckContext.Set<T>().Remove(GetById(id));
            _truckContext.SaveChanges();
        }

    }
}
