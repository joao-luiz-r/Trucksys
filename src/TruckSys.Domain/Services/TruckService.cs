using TruckSys.Domain.Interfaces.Repository;
using TruckSys.Domain.Interfaces.Services;
using TruckSys.Entities;

namespace TruckSys.Domain.Services
{
    public class TruckService : ITruckService
    {
        private readonly ITruckRepository _truckRepository;

        public TruckService(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }

        public Truck Add(Truck entity)
        {
            if (!Validate(ref entity))
                return entity;
            return _truckRepository.Add(entity);
        }

        public void Delete(int id)
        {
            _truckRepository.Delete(id);    
        }

        public IEnumerable<Truck> GetAll()
        {
            return _truckRepository.GetAll();
        }

        public Truck GetById(int id)
        {
            return _truckRepository.GetById(id);
        }

        public Truck Update(Truck entity)
        {
            if (!Validate(ref entity))
               return entity;
            return _truckRepository.Update(entity);
        }

        private bool Validate(ref Truck entity)
        {
            ValidateModelo(ref entity);
            ValidateAnoFabricacao(ref entity);
            ValidateAnoModelo(ref entity);
            return !entity.errormessages.Any();
        }

        private void ValidateModelo(ref Truck truck)
        {
            if (truck.Modelo != "FH" && truck.Modelo != "FM")
                truck.errormessages.Add("Modelo precisa ser FH ou FM!");
        }
        private void ValidateAnoFabricacao(ref Truck truck)
        {
            if (truck.AnoFabricacao != DateTime.Today.Year)
                truck.errormessages.Add($"Ano de Fabricação precisa ser {DateTime.Today.Year}!");
        }
        private void ValidateAnoModelo(ref Truck truck)
        {
            if (truck.AnoModelo < DateTime.Today.Year)
                truck.errormessages.Add($"Ano do Modelo precisa ser maior ou igual a {DateTime.Today.Year}!");
        }

    }
}
