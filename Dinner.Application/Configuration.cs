using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Dinner.Application
{
    public static class Configuration
    {
        public static IServiceCollection AddAppServices(this IServiceCollection Services)
        {
            //Services.AddMediatR(typeof(Configuration).Assembly);
            Services.AddMediatR(ctg =>
            {
                ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            return Services;
        }
    }
}
