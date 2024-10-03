using Dinner.Application.Common.Interfaces.Authentication;
using Dinner.Application.Common.Interfaces.Repositories;
using Dinner.Infrastructure.Authentication;
using Dinner.Infrastructure.Data;
using Dinner.Infrastructure.Interceptors;
using Dinner.Infrastructure.Repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace Dinner.Infrastructure
{
    public static class Configuration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection Services,
            IConfiguration Configuration)
        {
            Services.AddSingleton<IJWTTokenGenerator, JwtTokenGenerator>();
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            Services.AddScoped<PublishedDomainEventsInterceptor>();
            Services.AddIdentityServices(Configuration);
            return Services;
        }


        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DinnerDb")));
            /*services.AddIdentity<AppUser, IdentityRole>(
              opt =>
              {
                  opt.Password.RequireNonAlphanumeric = false;
                  opt.Password.RequiredLength = 6;
                  opt.Password.RequireLowercase = false;
                  opt.Password.RequireUppercase = false;
                  opt.Password.RequireDigit = false;
                  opt.SignIn.RequireConfirmedEmail = false;
              }
          )   //.AddRoleManager<RoleManager<IdentityRole>>()
              .AddEntityFrameworkStores<AppDbContext>()
              .AddSignInManager<SignInManager<AppUser>>()
          .AddUserManager<UserManager<AppUser>>()
              .AddDefaultTokenProviders();
*/
            var jwt = new JwtSettings();
            configuration.Bind("JwtSetting", jwt);
            services.AddSingleton(Options.Create(jwt));
           
            var secretKey = jwt.JwtKey;
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(secretKey));

            services.AddAuthentication(cfg =>
            {
                cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer(op =>
               {
                   op.TokenValidationParameters = new TokenValidationParameters()
                   {
                       ValidateIssuerSigningKey = true,
                       ValidateIssuer = true,
                       ValidIssuer = jwt.Issuer,
                       ValidateAudience = true,
                       ValidAudience = jwt.Audience,
                       IssuerSigningKey = key,
                       ValidateLifetime = true,

                   };
               });

            return services;
        }
    }
}
