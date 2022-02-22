using AutoMapper;
using CarDealer.Core.Models.InputModels;
using CarDealer.Core.Models.OutputModels;
using CarDealer.Data.Models;

namespace CarDealer.Core.Mapping
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            this.CreateMap<CarInputModel, Car>();

            this.CreateMap<Car, CarPreviewModel>();

            this.CreateMap<Car, CarDetailsModel>();
        }
    }
}
