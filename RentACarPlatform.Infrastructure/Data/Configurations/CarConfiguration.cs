using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACarPlatform.Infrastructure.Data.Models;

namespace RentACarPlatform.Infrastructure.Data.Configurations
{
    internal class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(CreateCars());
        }

        private List<Car> CreateCars()
        {
            List<Car> cars = new List<Car>()
            {

                new Car()
                {
                    Id = 1,
                    Make = "Mercedes-Benz",
                    Model = "E 350",
                    FuelType = "Дизел",
                    Gearbox = "Автоматична",
                    Year = "2011",
                    Doors = 4,
                    Seats = 5,
                    TankCapacity = 80,
                    FuelConsumption = 8.00,
                    TrunkVolume = 540,
                    Horsepower = 265,
                    Cubage = 3500,
                    PricePerDay = 250M,
                    ImageUrl = "https://i.ytimg.com/vi/QQk2WVpkck0/maxresdefault.jpg",
                    Availability = true,
                    LocationId = 1,
                    CategoryId = 1,
                    PurposeId = 7

                },

                new Car()
                {
                    Id = 2,
                    Make = "Mercedes-Benz",
                    Model = "S 500",
                    FuelType = "Бензин",
                    Gearbox = "Автоматична",
                    Year = "2018",
                    Doors = 4,
                    Seats = 5,
                    TankCapacity = 80,
                    FuelConsumption = 15.00,
                    TrunkVolume = 560,
                    Horsepower = 435,
                    Cubage = 5000,
                    PricePerDay = 400M,
                    ImageUrl = "https://rentaluxcar.bg/wp-content/uploads/2018/09/mercedes-s500-5.jpg",
                    Availability = true,
                    LocationId = 1,
                    CategoryId = 1,
                    PurposeId = 7

                },

                 new Car()
                {
                    Id = 3,
                    Make = "Audi",
                    Model = "A8",
                    FuelType = "Бензин",
                    Gearbox = "Автоматична",
                    Year = "2021",
                    Doors = 4,
                    Seats = 5,
                    TankCapacity = 80,
                    FuelConsumption = 14.50,
                    TrunkVolume = 520,
                    Horsepower = 350,
                    Cubage = 3000,
                    PricePerDay = 500M,
                    ImageUrl = "https://media.ed.edmunds-media.com/audi/a8/2021/oem/2021_audi_a8_sedan_l_fq_oem_2_815.jpg",
                    Availability = true,
                    LocationId = 1,
                    CategoryId = 1,
                    PurposeId = 7

                },

                  new Car()
                {
                    Id = 4,
                    Make = "Bentley",
                    Model = "Bentayga",
                    FuelType = "Бензин",
                    Gearbox = "Автоматична",
                    Year = "2020",
                    Doors = 4,
                    Seats = 5,
                    TankCapacity = 85,
                    FuelConsumption = 20.00,
                    TrunkVolume = 520,
                    Horsepower = 550,
                    Cubage = 4000,
                    PricePerDay = 700M,
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/9/94/2020_Bentley_Bentayga_facelift.jpg",
                    Availability = true,
                    LocationId = 1,
                    CategoryId = 3,
                    PurposeId = 7

                },

                  new Car()
                {
                    Id = 5,
                    Make = "Porsche",
                    Model = "Cayenne",
                    FuelType = "Бензин",
                    Gearbox = "Автоматична",
                    Year = "2019",
                    Doors = 4,
                    Seats = 5,
                    TankCapacity = 75,
                    FuelConsumption = 16.00,
                    TrunkVolume = 600,
                    Horsepower = 340,
                    Cubage = 3000,
                    PricePerDay = 650M,
                    ImageUrl = "https://www.ccarprice.com/products/Porsche-Cayenne-S-2019.png",
                    Availability = true,
                    LocationId = 1,
                    CategoryId = 3,
                    PurposeId = 7

                },

                  new Car()
                {
                    Id = 6,
                    Make = "Land Rover",
                    Model = "Range Rover",
                    FuelType = "Дизел",
                    Gearbox = "Автоматична",
                    Year = "2020",
                    Doors = 4,
                    Seats = 5,
                    TankCapacity = 85,
                    FuelConsumption = 16.50,
                    TrunkVolume = 2450,
                    Horsepower = 351,
                    Cubage = 3000,
                    PricePerDay = 700M,
                    ImageUrl = "https://i.ytimg.com/vi/EP9BFxNb_3s/maxresdefault.jpg",
                    Availability = true,
                    LocationId = 1,
                    CategoryId = 3,
                    PurposeId = 7

                },

                  new Car()
                {
                    Id = 7,
                    Make = "Mercedes-Benz",
                    Model = "S 560",
                    FuelType = "Бензин",
                    Gearbox = "Автоматична",
                    Year = "2020",
                    Doors = 2,
                    Seats = 4,
                    TankCapacity = 80,
                    FuelConsumption = 16.00,
                    TrunkVolume = 700,
                    Horsepower = 470,
                    Cubage = 4000,
                    PricePerDay = 650M,
                    ImageUrl = "https://dubicars.com/images/485195/1000x564/car-to-point-automobile-fze/6f4b4686-0144-4e36-858d-8053c0c6a608.jpg",
                    Availability = true,
                    LocationId = 1,
                    CategoryId = 5,
                    PurposeId = 7

                },

                  new Car()
                {
                    Id = 8,
                    Make = "Volkswagen",
                    Model = "Passat",
                    FuelType = "Дизел",
                    Gearbox = "Автоматична",
                    Year = "2020",
                    Doors = 4,
                    Seats = 5,
                    TankCapacity = 65,
                    FuelConsumption = 8.00,
                    TrunkVolume = 1200,
                    Horsepower = 240,
                    Cubage = 2000,
                    PricePerDay = 300M,
                    ImageUrl = "https://cdn.jdpower.com/JDPA_2020%20Volkswagen%20Passat%20R-Line%20Aurora%20Red%20Front%20View%20Small_edited.jpg",
                    Availability = true,
                    LocationId = 1,
                    CategoryId = 1,
                    PurposeId = 4
                },

                  new Car()
                {
                    Id = 9,
                    Make = "Volkswagen",
                    Model = "Passat",
                    FuelType = "Дизел",
                    Gearbox = "Автоматична",
                    Year = "2020",
                    Doors = 4,
                    Seats = 5,
                    TankCapacity = 65,
                    FuelConsumption = 8.00,
                    TrunkVolume = 1400,
                    Horsepower = 240,
                    Cubage = 2000,
                    PricePerDay = 300M,
                    ImageUrl = "https://cdn.jdpower.com/JDPA_2020%20Volkswagen%20Passat%20R-Line%20Aurora%20Red%20Front%20View%20Small_edited.jpg",
                    Availability = true,
                    LocationId = 1,
                    CategoryId = 2,
                    PurposeId = 5
                },

                  new Car()
                {
                    Id = 10,
                    Make = "Skoda",
                    Model = "Octavia",
                    FuelType = "Дизел",
                    Gearbox = "Автоматична",
                    Year = "2017",
                    Doors = 4,
                    Seats = 5,
                    TankCapacity = 60,
                    FuelConsumption = 7.00,
                    TrunkVolume = 1300,
                    Horsepower = 185,
                    Cubage = 2000,
                    PricePerDay = 280M,
                    ImageUrl = "https://automedia.investor.bg/media/files/resized/uploadedfiles/640x0/b26/c230bdb3a7c8e9242f83577101b65b26-1920px-2018-skoda-octavia-5e-my185-110tsi-station-wagon-2018-11-02.jpg",
                    Availability = true,
                    LocationId = 1,
                    CategoryId = 2,
                    PurposeId = 5
                },

                  new Car()
                {
                    Id = 11,
                    Make = "Peugeot",
                    Model = "307",
                    FuelType = "Дизел",
                    Gearbox = "Автоматична",
                    Year = "2009",
                    Doors = 2,
                    Seats = 4,
                    TankCapacity = 50,
                    FuelConsumption = 6.00,
                    TrunkVolume = 350,
                    Horsepower = 136,
                    Cubage = 2000,
                    PricePerDay = 200M,
                    ImageUrl = "https://i.ebayimg.com/images/g/6akAAOSwFE1jZ3bV/s-l1600.jpg",
                    Availability = true,
                    LocationId = 1,
                    CategoryId = 6,
                    PurposeId = 3
                },

                  new Car()
                {
                    Id = 12,
                    Make = "Renault",
                    Model = "Kadjar",
                    FuelType = "Дизел",
                    Gearbox = "Автоматична",
                    Year = "2017",
                    Doors = 4,
                    Seats = 5,
                    TankCapacity = 65,
                    FuelConsumption = 8.00,
                    TrunkVolume = 1450,
                    Horsepower = 130,
                    Cubage = 1600,
                    PricePerDay = 200M,
                    ImageUrl = "https://feassets.bymycar.fr/vo/13/191976/0/renault-kadjar-tce-130-energy-occasion-2017-epinal.jpg",
                    Availability = true,
                    LocationId = 1,
                    CategoryId = 3,
                    PurposeId = 4
                },

                  new Car()
                {
                    Id = 13,
                    Make = "Audi",
                    Model = "A4",
                    FuelType = "Дизел",
                    Gearbox = "Автоматична",
                    Year = "2008",
                    Doors = 2,
                    Seats = 4,
                    TankCapacity = 65,
                    FuelConsumption = 7.50,
                    TrunkVolume = 315,
                    Horsepower = 163,
                    Cubage = 2500,
                    PricePerDay = 170M,
                    ImageUrl = "http://usclassifieds4all.com/pictures/2960595/main.jpg",
                    Availability = true,
                    LocationId = 1,
                    CategoryId = 6,
                    PurposeId = 4
                },

                  new Car()
                {
                    Id = 14,
                    Make = "Volkswagen",
                    Model = "Scirocco",
                    FuelType = "Дизел",
                    Gearbox = "Автоматична",
                    Year = "2013",
                    Doors = 2,
                    Seats = 4,
                    TankCapacity = 55,
                    FuelConsumption = 6.00,
                    TrunkVolume = 300,
                    Horsepower = 140,
                    Cubage = 2000,
                    PricePerDay = 200M,
                    ImageUrl = "https://www.motortrend.com/uploads/sites/5/2013/11/2013-Volkswagen-Scirocco-R-front-three-quarters1.jpg",
                    Availability = true,
                    LocationId = 1,
                    CategoryId = 5,
                    PurposeId = 4
                },

                  new Car()
                {
                    Id = 15,
                    Make = "Volkswagen",
                    Model = "Golf",
                    FuelType = "Дизел",
                    Gearbox = "Автоматична",
                    Year = "2013",
                    Doors = 4,
                    Seats = 5,
                    TankCapacity = 50,
                    FuelConsumption = 5.00,
                    TrunkVolume = 1600,
                    Horsepower = 110,
                    Cubage = 1600,
                    PricePerDay = 210M,
                    ImageUrl = "https://aaaautoeuimg.vshcdn.net/thumb/700122107_640x480x95.jpg?51677",
                    Availability = true,
                    LocationId = 1,
                    CategoryId = 2,
                    PurposeId = 2
                },
        };

            return cars;
        }
    }
}
