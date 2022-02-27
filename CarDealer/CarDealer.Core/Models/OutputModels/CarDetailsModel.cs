using CarDealer.Common;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Core.Models.OutputModels
{
    public class CarDetailsModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.CarMakeModelMinLength)]
        [MaxLength(GlobalConstants.CarMakeModelMaxLength)]
        public string Make { get; set; }

        [Required]
        [MinLength(GlobalConstants.CarMakeModelMinLength)]
        [MaxLength(GlobalConstants.CarMakeModelMaxLength)]
        public string Model { get; set; }

        [Required]
        [Range(GlobalConstants.CarMinYear, GlobalConstants.CarMaxYear)]
        public int Year { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "-")]
        [RegularExpression(GlobalConstants.CarColorRegex, ErrorMessage = "Color should contain only letters")]
        public string? Color { get; set; }

        [Display(Name = "Engine Capacity")]
        [Required]
        [Range(GlobalConstants.CarEngineCapacityMinValue, GlobalConstants.CarEngineCapacityMaxValue)]
        public double EngineCapacity { get; set; }

        [Required]
        [Range(GlobalConstants.CarMinHorsepower, GlobalConstants.CarMaxHorsepower)]
        public int Horsepower { get; set; }
    }
}
