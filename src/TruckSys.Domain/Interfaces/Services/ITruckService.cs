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
