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

        public CarService()
        {
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

                throw new ArgumentException("Invalid Id");
            }
;
        }

        public async Task<CarPreviewModel> GetCarPreviewById(int id)
        {
            try
            {
                Car car = await data.GetByIdAsync<Car>(id);
                var mapped = mapper.Map<Car, CarPreviewModel>(car);
                return mapped;
            }
            catch (Exception)
            {
                throw new ArgumentException("Invalid Id");
            }
            
        }

        public async Task<ICollection> GetAllCarsPreview()
        {
            var cars = data.All<Car>().ToArray();
            List<CarPreviewModel> result = new List<CarPreviewModel>();
            foreach (var car in cars)
            {
                var mapped = mapper.Map<Car, CarPreviewModel>(car);
                result.Add(mapped);
            }
            return result;
        }
        public async Task<ICollection> GetAllCarsPreviewWhere<Car>(Expression<Func<Car, bool>> search)
        {
            /* var cars =await data.All<Car>(search).ToArray();
             List<CarPreviewModel> result = new List<CarPreviewModel>();
             foreach (var car in cars)
             {
                 var mapped = mapper.Map<Car, CarPreviewModel>(car);
                 result.Add(mapped);
             }

             return result;*/
            throw new NotImplementedException();


        }
        public Task EditById(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
