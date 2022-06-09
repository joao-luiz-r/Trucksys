using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckSys.Domain.Interfaces.Repository;
using TruckSys.Entities;
using TruckSys.Infra.Data;

namespace TruckSys.Infra.Repository
{
    public class TruckRepository : EFRepository<Truck> , ITruckRepository
    {
        public TruckRepository(TruckContext context) : base(context)
        {

        }

    }
}
