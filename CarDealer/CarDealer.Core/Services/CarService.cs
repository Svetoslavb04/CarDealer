using AutoMapper;
using CarDealer.Core.Services.Contracts;
using CarDealer.Data;

namespace CarDealer.Core.Services
{
    public class CarService : ICarService
    {
        private ICarDealerRepository data;
        private IMapper mapper;

        public CarService(ICarDealerRepository _data, IMapper _mapper)
        {
            data = _data;
            mapper = _mapper;
        }

        //To do methods
    }
}
