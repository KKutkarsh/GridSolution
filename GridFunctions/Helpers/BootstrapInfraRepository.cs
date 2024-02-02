using GridFunction.Infrastructure;
using GridFunctions.Core.Entities;
using GridFunctions.Services;
using GridFunctions.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GridFunctions.Helpers
{
    internal static class BootstrapInfraRepository
    {
        public static IServiceCollection AddInfraRepository<T>(this IServiceCollection services) where T : BaseEntity
        {
            static IBaseRepository<T> factory(IServiceProvider serviceProvider)
            {
                IConfiguration configuration = serviceProvider.GetService<IConfiguration>();
                var environmentHelper = configuration.Get<EnvironmentHelperService>();
                var connectionString = environmentHelper.GetEnvironmentVariable(IEnvironmentHelperService.SQLServerConnectionString);
                return new BaseRepository<T>(connectionString);
            }

            return services.AddScoped(factory);
        }
    }
}
