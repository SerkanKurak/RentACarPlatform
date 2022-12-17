using RentACarPlatform.Core.Models.Admin;

namespace RentACarPlatform.Core.Contracts.Admin
{
    public interface IUserService
    {
        Task<string> UserFullName(string userId);

        Task<IEnumerable<UserServiceModel>> All();       
    }
}
