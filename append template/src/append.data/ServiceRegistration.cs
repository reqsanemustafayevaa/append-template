using append.core.Repositories.Interfaces;
using append.data.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace append.data
{
    public static class ServiceRegistration
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();
        }
    }
}
