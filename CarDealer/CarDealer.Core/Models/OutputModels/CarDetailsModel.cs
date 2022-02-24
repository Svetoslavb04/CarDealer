namespace CarDealer.Core.Models.OutputModels
{
    public class CarDetailsModel
    {
        public int Id { get; set; } 
        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string? Color { get; set; }

        public double EngineCapacity { get; set; }

        public int Horsepower { get; set; }
    }
}
