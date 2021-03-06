using System.ComponentModel.DataAnnotations;

namespace CarDealer.Core.Models.OutputModels
{
    public class CarPreviewModel
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"--> {Make} {Model}\n    ID: {Id}\n    Year: {Year}";
        }
    }
}
