using Microsoft.Extensions.DependencyInjection;
using Services.Auth;
using Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }

        public static void AddAuth(this IServiceCollection services, AuthSettings settings) 
        { 
            services.AddSingleton<IAuthService, AuthService>(x => new AuthService(settings ?? new AuthSettings()));
        }
    }
}
