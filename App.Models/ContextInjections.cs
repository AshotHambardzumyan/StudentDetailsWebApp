using System;
using System.Linq;
using System.Text;
using App.Models.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace App.Models
{
    public static class ContextInjections
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services)
        {
            services.AddSingleton<IUniversityDbContext, UniversityDbContext>();

            return services;
        }
    }
}
