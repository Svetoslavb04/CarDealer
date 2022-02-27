using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Core.Models.InputModels;
using CarDealer.Core.Models.OutputModels;
using CarDealer.Core.Services.Contracts;
using CarDealer.Data;
using CarDealer.Data.Models;
using System.Collections;
using System.Linq.Expressions;

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
            try
            {
                await data.DeleteAsync<Car>(id);
                await data.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new ArgumentException("Invalid Id");
            }
            
        }
        public async Task<CarDetailsModel> GetCarDetailsById(int id)
        {
            try
            {
                Car car = await data.GetByIdAsync<Car>(id);

                var mapped = mapper.Map<Car, CarDetailsModel>(car);

                return mapped;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable> GetAllCarsPreview()
        {
            return data.All<Car>()
                .ProjectTo<CarPreviewModel>(this.mapper.ConfigurationProvider)
                .ToArray();
        }
        public async Task<IEnumerable> GetAllCarsPreviewSearchedByMakeOrModel(string search)
        {
            return data.All<Car>()
                .Where(c => c.Make.ToLower().Contains(search.ToLower()) || c.Model.ToLower().Contains(search.ToLower()))
                .ProjectTo<CarPreviewModel>(this.mapper.ConfigurationProvider)
                .ToArray();
        }

        public async Task<IEnumerable> GetTopThreeMostPowerfulCars()
        {
            return data.All<Car>()
                .OrderByDescending(c => c.Horsepower)
                .Take(3)
                .ProjectTo<CarDetailsModel>(this.mapper.ConfigurationProvider)
                .ToArray();
        }

        public async Task<bool> EditCar(CarDetailsModel carModel)
        {
            var car = await data.GetByIdAsync<Car>(carModel.Id);

            if (car == null)
            {
                return false;
            }

            car.Make = carModel.Make;
            car.Model = carModel.Model;
            car.Year = carModel.Year;
            car.EngineCapacity = carModel.EngineCapacity;
            car.Color = carModel.Color;
            car.Horsepower = carModel.Horsepower;

            try
            {
                await data.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task DeleteById(int id)
        {
            await data.DeleteAsync<Car>(id);
            await data.SaveChangesAsync();
        }
    }
}
