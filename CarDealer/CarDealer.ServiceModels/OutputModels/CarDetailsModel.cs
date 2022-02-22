namespace CarDealer.ServiceModels.OutputModels
{
    public class CarDetailsModel
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string? Color { get; set; }

        public double EngineCapacity { get; set; }

        public int Horsepower { get; set; }
    }
}
