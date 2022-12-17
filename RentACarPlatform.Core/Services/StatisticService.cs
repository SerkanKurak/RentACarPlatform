using Microsoft.EntityFrameworkCore;
using RentACarPlatform.Core.Contracts;
using RentACarPlatform.Core.Models.Statics;
using RentACarPlatform.Infrastructure.Data.Common;
using RentACarPlatform.Infrastructure.Data.Models;

namespace RentACarPlatform.Core.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IRepository repo;

        public StatisticService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<StatisticServiceModel> Total()
        {
            int totalCars = await repo.AllReadonly<Car>()
                .CountAsync(h => h.IsActive);
            int rentedCars = await repo.AllReadonly<Car>()
                .CountAsync(h => h.IsActive && h.RenterId != null);

            return new StatisticServiceModel()
            {
                TotalCars = totalCars,
                TotalRents = rentedCars
            };
        }
    }
}
