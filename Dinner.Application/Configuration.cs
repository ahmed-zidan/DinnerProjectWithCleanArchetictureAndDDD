using Dinner.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Dinner.Application
{
    public static class Configuration
    {
        public static IServiceCollection AddAppServices(this IServiceCollection Services)
        {
            Services.AddTransient<IAuthenticationService, AuthenticationService>();
            return Services;
        }
    }
}
