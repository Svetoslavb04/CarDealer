using CarDealer.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Core.Models.InputModels
{
    public class CarInputModel
    {
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

        [RegularExpression(GlobalConstants.CarColorRegex)]
        public string? Color { get; set; }

        [Required]
        [Range(GlobalConstants.CarEngineCapacityMinValue, GlobalConstants.CarEngineCapacityMaxValue)]
        public double EngineCapacity { get; set; }

        [Required]
        [Range(GlobalConstants.CarMinHorsepower, GlobalConstants.CarMaxHorsepower)]
        public int Horsepower { get; set; }
    }
}
