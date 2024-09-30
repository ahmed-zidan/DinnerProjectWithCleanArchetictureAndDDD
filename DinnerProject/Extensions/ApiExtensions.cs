using Dinner.Api.helper;

namespace Dinner.Api.Extensions
{
    public static class ApiExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services) {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(AppMapper));
            return services;
        }
    }
}
