using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.DependencyInjection;
using MyHistory.Application.Common.Interfaces.Authentication;
using MyHistory.Application.Common.Interfaces.Persistence;
using MyHistory.Application.Common.Interfaces.Services;
using MyHistory.Infrastructure.Authentication;
using MyHistory.Infrastructure.Persistence;
using MyHistory.Infrastructure.Services;

namespace MyHistory.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this  IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DatetimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
