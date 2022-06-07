using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TruckSys.Entities;

namespace TruckSys.Domain.Interfaces.Services
{
    public interface ITruckService
    {
        Truck Add(Truck entity);
        void Update(Truck entity);
        void Delete(Truck entity);
        IEnumerable<Truck> GetAll();
        Truck GetById(int id);
        IEnumerable<Truck> Search(Expression<Func<Truck, bool>> predicado);
    }
}
