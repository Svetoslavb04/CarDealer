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

        public Task<CarPreviewModel> GetCarPreviewById(int id);

        public Task<CarDetailsModel> GetCarDetailsById(int id);

        public Task<ICollection> GetAllCarsPreview();

        public Task<ICollection> GetAllCarsPreviewWhere<T>(Expression<Func<T, bool>> search);

        public Task EditById(int id);
    };
}
