using CarDealer.Data.Common;

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
