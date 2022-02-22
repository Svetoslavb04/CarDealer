using CarDealer.Services.Contracts;
//В училище няма .Net 6 и всичко гърми защото направих проектите на .Net 5, а всички други са на .Net 6. После ще ги оправя.
namespace CarDealer.Services
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
