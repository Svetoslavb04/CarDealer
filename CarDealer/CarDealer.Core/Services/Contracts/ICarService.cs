using CarDealer.Core.Models.InputModels;
using CarDealer.Core.Models.OutputModels;
using System.Collections;
using System.Linq.Expressions;

namespace CarDealer.Core.Services.Contracts
{
    public interface ICarService
    {
        public Task AddCar(CarInputModel carModel);

        public Task RemoveCarById(int id);

        public Task<CarDetailsModel> GetCarDetailsById(int id);

        public Task<IEnumerable> GetAllCarsPreview();

        public Task<IEnumerable> GetAllCarsPreviewSearchedByMakeOrModel(string search);

        public Task<bool> EditCar(CarDetailsModel carModel);

        public Task DeleteById(int id);
    };
}
