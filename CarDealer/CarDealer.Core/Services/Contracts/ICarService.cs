using CarDealer.Core.Models.InputModels;
using CarDealer.Core.Models.OutputModels;

namespace CarDealer.Core.Services.Contracts
{
    public interface ICarService
    {
        public Task AddCar(CarInputModel carModel);

        public Task RemoveCarById(int id);

        public Task<CarPreviewModel> GetCarPreviewById(int id);

        public Task<CarDetailsModel> GetCarDetailsById(int id);


    }
}
