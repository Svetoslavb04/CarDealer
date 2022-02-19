using CarDealer.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Data
{
    public class CarDealerRepository : Repository
    {
        public CarDealerRepository(CarDealerContext context)
        {   
            this.Context = context;
        }
    }
}
