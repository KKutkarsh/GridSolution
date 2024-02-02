using GridFunctions.Core.Entities;
using GridFunctions.Handlers;
using GridFunctions.Handlers.Interfaces;
using GridFunctions.Helpers;
using GridFunctions.Services;
using GridFunctions.Services.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(GridFunctions.Startup))]
namespace GridFunctions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();
            builder.Services.AddLogging();

            builder.Services.AddSingleton<IEnvironmentHelperService, EnvironmentHelperService>();
            builder.Services.AddScoped<IMeasurementService, MeasurementService>();
            builder.Services.AddScoped<ILatestValueFunctionHandler, LatestValueFunctionHandler>();
            builder.Services.AddScoped<ICollectedValueFunctionHandler, CollectedValueFunctionHandler>();

            //Repositories
            builder.Services.AddInfraRepository<Grid>();
            builder.Services.AddInfraRepository<GridDetail>();
            builder.Services.AddInfraRepository<GridRegion>();
            builder.Services.AddInfraRepository<GridNode>();
            builder.Services.AddInfraRepository<Measure>();
        }
    }
}
