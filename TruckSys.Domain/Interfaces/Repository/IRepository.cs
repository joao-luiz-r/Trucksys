using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TruckSys.Domain.Interfaces.Repository
{
    public interface IRepository<T> where T : class 
    {
        T Add(T entity);    
        void Update(T entity);     
        void Delete(T entity);
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> Search(Expression<Func<T, bool>> predicado);
    }
}
