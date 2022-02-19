using CarDealer.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Data
{
    public class CarDealerRepository : Repository, ICarDealerRepository
    {
        public CarDealerRepository(CarDealerContext context)
        {   
            this.Context = context;
        }
    }
}
