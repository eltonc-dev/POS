using Microsoft.Extensions.DependencyInjection;
using GuestDataAccess.AutoMapper;
using RegisterDomain;
using GuestDataAccess.Guest;

namespace GuestDataAccess
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGuestDataAccessDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            // DI dependencies
            services.AddSingleton<GuestContext>();
            services.AddScoped<IGuestDAO, GuestDAO>();

            return services;
        }
    }
}
