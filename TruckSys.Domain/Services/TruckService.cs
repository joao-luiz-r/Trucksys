using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TruckSys.Domain.Interfaces.Repository;
using TruckSys.Domain.Interfaces.Services;
using TruckSys.Entities;

namespace TruckSys.Domain.Services
{
    internal class TruckService : ITruckService
    {
        private readonly ITruckRepository _truckRepository;

        public TruckService(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }

        public Truck Add(Truck entity)
        {
            if (!ValidateModel(entity))
                return entity;
            return _truckRepository.Add(entity);
        }

        public void Delete(Truck entity)
        {
            _truckRepository.Delete(entity);    
        }

        public IEnumerable<Truck> GetAll()
        {
            return _truckRepository.GetAll();
        }

        public Truck GetById(int id)
        {
            return _truckRepository.GetById(id);
        }

        public IEnumerable<Truck> Search(Expression<Func<Truck, bool>> predicate)
        {
            return _truckRepository.Search(predicate);
        }

        public void Update(Truck entity)
        {
            _truckRepository.Update(entity);
        }

        private bool ValidateModel(Truck truck)
        {
            if (truck.Modelo != "FH" && truck.Modelo != "FM")
                truck.errormessages.Add("Modelo precisa ser FH ou FM!");
            return truck.errormessages.Any();
        }

    }
}
