using AutoMapper;

namespace CarDealer.Mapping
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            this.CreateMap<Car, CarInputModel>();

            this.CreateMap<Car, CarPreviewModel>();

            this.CreateMap<Car, CarDetailsModel>();
        }
    }
}
