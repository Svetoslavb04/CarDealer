using CarDealer.Core.Models.InputModels;

namespace CarDealer.Core.Services.Contracts
{
    public interface ICarService
    {
        public Task AddCar(CarInputModel carModel);
        //To Do Methods
    }
}
