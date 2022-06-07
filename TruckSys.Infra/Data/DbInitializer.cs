using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckSys.Infra.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TruckContext context)
        {
            context.Database.EnsureCreated();   
        }

    }
}
