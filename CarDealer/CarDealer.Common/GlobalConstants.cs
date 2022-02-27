namespace CarDealer.Common
{
    public static class GlobalConstants
    {
        public const int CarMakeModelMinLength = 2;

        public const int CarMakeModelMaxLength = 30;

        public const int CarMinYear = 1886;

        public const int CarMaxYear = 2022;

        public const string CarColorRegex = @"^[a-z A-Z]+$";

        public const double CarEngineCapacityMinValue = 0.1;

        public const double CarEngineCapacityMaxValue = 50;

        public const double CarMinHorsepower = 1;

        public const double CarMaxHorsepower = 10000;

    }
}
