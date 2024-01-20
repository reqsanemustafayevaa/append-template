using append.business.Services.Implementations;
using append.business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace append.business
{
    public static class ServiceRegistration
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<ITeamMemberService, TeamMemberService>();
            services.AddScoped<IAuthService, AuthService>();
        }

    }
}
