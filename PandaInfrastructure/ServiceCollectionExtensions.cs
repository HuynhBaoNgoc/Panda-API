using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PandaApplication.Interfaces.Repositories;
using PandaApplication.Interfaces.Repositories.Generic;
using PandaApplication.Services;
using PandaApplication.Services.Interfaces;
using PandaInfrastructure.ConnectionStrings;
using PandaInfrastructure.Repositories;
using PandaInfrastructure.Repositories.Generic;

namespace PandaInfrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDatabase(services, configuration);
            AddServices(services);
            AddRepositories(services);

            return services;
        }

        private static void AddDatabase(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConnectionStringService, ConnectionStringService>();
            services.AddDbContext<PandaDbContext>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped(typeof(IGeneralRepository<>), typeof(GeneralRepository<>));
            services.AddTransient<ICityRepository, CityRepository>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<ICityService, CityService>();
        }
    }
}
