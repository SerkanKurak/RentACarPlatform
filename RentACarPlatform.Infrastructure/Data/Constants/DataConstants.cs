namespace RentACarPlatform.Infrastructure.Data.Constants
{

    /// <summary>
    /// All validation constants for database
    /// </summary>

    public static class DataConstants
    {
        /// <summary>
        /// Agent entity validation constants
        /// </summary>
        public static class AgentData
        {
            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;
        }


        /// <summary>
        /// CarCategory entity validation constant
        /// </summary>
        public static class CarCategoryData
        {
            public const int NameMaxLength = 10;
        }


        /// <summary>
        /// CarPurpose entity validation constant
        /// </summary>
        public static class CarPurposeData
        {
            public const int NameMaxLength = 20;
        }


        /// <summary>
        /// Car entity validation constants
        /// </summary>
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


            public const int MaxImageUrlLenght = 300;
        }


        /// <summary>
        /// Location entity validation constant
        /// </summary>
        public static class LocationData
        {
            public const int NameMaxLength = 30;
        }



        /// <summary>
        /// ApplicationUser entity validation constants
        /// </summary>
        public static class ApplicationUserData
        {
            public const int FirstNameMaxLength = 20;

            public const int LastNameMaxLength = 20;

            public const int CountryNameMaxLength = 60;
        }



        /// <summary>
        /// Protection entity validation constant
        /// </summary>
        public static class ProtectionData
        {
            public const int NameMaxLength = 8;     
        }
    }
}
