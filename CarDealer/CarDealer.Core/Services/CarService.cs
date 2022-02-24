using AutoMapper;
using CarDealer.Core.Models.InputModels;
using CarDealer.Core.Models.OutputModels;
using CarDealer.Core.Services.Contracts;
using CarDealer.Data;
using CarDealer.Data.Models;

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

        //An example. You receive a carModel of type CarInputModel.
        //In carModel there is no Id so we convert it to a car with the mapper.
        //Mapper sets the Id to 0 and the color to null 
        //When you add the car in the db its Id will be automatically set 
        public async Task AddCar(CarInputModel carModel)
        {
            var car = mapper.Map<CarInputModel, Car>(carModel);

            try
            {
                await data.AddAsync<Car>(car);
                await data.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new ArgumentException("Invalid car!");
            }
        }
        public async Task RemoveCarById(int id)
        {
            await data.DeleteAsync<Car>(id);
            await data.SaveChangesAsync();
        }
        public async Task<CarDetailsModel> GetCarDetailsById(int id)
        {
            Car car = await data.GetByIdAsync<Car>(id);

            var mapped = mapper.Map<Car, CarDetailsModel>(car);

            return mapped;
        }

        public async Task<CarPreviewModel> GetCarPreviewById(int id)
        {
            Car car = await data.GetByIdAsync<Car>(id);

            var mapped = mapper.Map<Car, CarPreviewModel>(car);

            return mapped;
        }



        //To do methods
    }
}
