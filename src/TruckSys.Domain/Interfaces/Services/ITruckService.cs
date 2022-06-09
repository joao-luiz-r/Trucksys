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
        Truck Update(Truck entity);
        void Delete(int id);
        IEnumerable<Truck> GetAll();
        Truck GetById(int id);
    }
}
