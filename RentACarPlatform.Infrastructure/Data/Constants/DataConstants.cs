namespace RentACarPlatform.Infrastructure.Data.Constants
{
    public static class DataConstants
    {
        public static class CarCategoryData
        {
            public const int NameMaxLength = 10;
        }

        public static class CarPurposeData
        {
            public const int NameMaxLength = 20;
        }

        public static class CarData
        {
            public const int MakeMinLength = 2;
            public const int MakeMaxLength = 20;


            public const int ModelMinLength = 2;
            public const int ModelMaxLength = 20;


            public const int FuelTypeMinLength = 3;
            public const int FuelTypeMaxLength = 12;


            public const int GearboxMinLength = 5;
            public const int GearboxMaxLength = 12;


            public const int DoorsMinCount = 2;
            public const int DoorsMaxCount = 5;


            public const int SeatsMinCount = 2;
            public const int SeatsMaxCount = 7;


            public const int MinTankCapacity = 30;
            public const int MaxTankCapacity = 100;


            public const double MinFuelConsumption = 3.00;
            public const double MaxFuelConsumption = 30.00;


            public const int MinHorsepower = 70;
            public const int MaxHorsepower = 800;


            public const int MinCubage = 1200;
            public const int MaxCubage = 6000;


            public const decimal MinPricePerDay = 50;
            public const decimal MaxPricePerDay = 1000;


            public const int MaxImageUrlLenght = 250;

        }

        public static class LocationData
        {
            public const int NameMaxLength = 30;
        }

        public static class ApplicationUserData
        {
            public const int FirstNameMaxLength = 20;

            public const int LastNameMaxLength = 20;

            public const int CountryNameMaxLength = 60;
        }

        public static class ProtectionData
        {
            public const int NameMaxLength = 8;

          
        }
    }
}
