using RentACarPlatform.Core.Models.Statics;

namespace RentACarPlatform.Core.Contracts
{
    public interface IStatisticService
    {
        Task<StatisticServiceModel> Total();
    }
}
