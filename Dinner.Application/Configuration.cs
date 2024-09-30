using Dinner.Application.Authentication.Commands.Register;
using Dinner.Application.Authentication.Common;
using Dinner.Application.Common.Behaviors;
using Dinner.Application.Errors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OneOf;
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
            Services.AddScoped(typeof(IPipelineBehavior<,>) , typeof(ValidationBehavior<,>));
           

            Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return Services;
        }
    }
}
