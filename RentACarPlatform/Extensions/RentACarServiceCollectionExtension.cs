using RentACarPlatform.Core.Contracts;
using RentACarPlatform.Core.Contracts.Admin;
using RentACarPlatform.Core.Exceptions;
using RentACarPlatform.Core.Services;
using RentACarPlatform.Core.Services.Admin;
using RentACarPlatform.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RentACarServiceCollectionExtension
    {
        /// <summary>
        /// All Application Services
        /// </summary>
 
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IAgentService, AgentService>();
            services.AddScoped<IGuard, Guard>();
           // services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
