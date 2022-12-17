using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentACarPlatform.Core.Contracts.Admin;
using RentACarPlatform.Core.Models.Admin;
using RentACarPlatform.Infrastructure.Data.Common;
using RentACarPlatform.Infrastructure.Data.Models;

namespace RentACarPlatform.Core.Services.Admin
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        private readonly UserManager<ApplicationUser> userManager;

        public UserService(
               IRepository _repo,
               UserManager<ApplicationUser> _userManager)
        {
            repo = _repo;
            userManager = _userManager;
        }

        public async Task<IEnumerable<UserServiceModel>> All()
        {
            List<UserServiceModel> result;

            result = await repo.AllReadonly<Agent>()
                .Where(a => a.User.IsActive)
                .Select(a => new UserServiceModel()
                {
                    UserId = a.UserId,
                    Email = a.User.Email,
                    FullName = $"{a.User.FirstName} {a.User.LastName}",
                    PhoneNumber = a.PhoneNumber
                })
                .ToListAsync();

            string[] agentIds = result.Select(a => a.UserId).ToArray();

            result.AddRange(await repo.AllReadonly<ApplicationUser>()
                .Where(u => agentIds.Contains(u.Id) == false)
                .Where(u => u.IsActive)
                .Select(u => new UserServiceModel()
                {
                    UserId = u.Id,
                    Email = u.Email,
                    FullName = $"{u.FirstName} {u.LastName}"
                }).ToListAsync());

            return result;
        }
    

        public async Task<string> UserFullName(string userId)
        {
            var user = await repo.GetByIdAsync<ApplicationUser>(userId);

            return $"{user?.FirstName} {user?.LastName}".Trim();
        }
    }
}
