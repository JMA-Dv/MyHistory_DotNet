using Microsoft.Extensions.DependencyInjection;
using MyHistory.Application.Services.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHistory.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAutheService, AuthenticationService>();
            return services;
        }
    }
}
