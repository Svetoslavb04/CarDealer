using System.ComponentModel.DataAnnotations;

namespace CarDealer.Data.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Make { get; set; }

        [MinLength(2)]
        [MaxLength(30)]
        public string Model { get; set; }

        [Required]
        [Range(1886, 2022)]
        public int Year { get; set; }
        
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string? Color { get; set; }

        [Required]
        [Range(0.1, 50)]
        public double EngineCapacity { get; set; }

        [Required]
        [Range(0,10000)]
        public int Horsepower { get; set; }
    }
}
