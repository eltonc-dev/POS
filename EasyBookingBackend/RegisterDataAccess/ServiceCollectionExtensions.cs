using Microsoft.Extensions.DependencyInjection;
using RegisterDataAccess.AutoMapper;
using RegisterDataAccess.RoomType;
using RegisterDataAccess.Room;
using RegisterDomain;
using System.Runtime.CompilerServices;

namespace RegisterDataAccess
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRegisterDataAccessDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            // DI dependencies
            services.AddSingleton<RegisterContext>();
            services.AddScoped<IRoomTypeDAO, RoomTypeDAO>();
            services.AddScoped<IRoomDAO, RoomDAO>();

            return services;
        }
    }
}
