using Dinner.Application.Common.Interfaces.Authentication;
using Dinner.Application.Common.Interfaces.Repositories;
using Dinner.Infrastructure.Authentication;
using Dinner.Infrastructure.Repos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Dinner.Infrastructure
{
    public static class Configuration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection Services,
            IConfiguration Configuration)
        {
            Services.Configure<JwtSettings>(Configuration.GetSection("JwtSetting"));
            Services.AddSingleton<IJWTTokenGenerator, JwtTokenGenerator>();
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            return Services;
        }
    }
}
