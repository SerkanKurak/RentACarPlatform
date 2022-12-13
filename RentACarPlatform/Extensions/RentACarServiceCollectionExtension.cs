using RentACarPlatform.Core.Contracts;
using RentACarPlatform.Core.Exceptions;
using RentACarPlatform.Core.Services;
using RentACarPlatform.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RentACarServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IGuard, Guard>();

            return services;
        }
    }
}
