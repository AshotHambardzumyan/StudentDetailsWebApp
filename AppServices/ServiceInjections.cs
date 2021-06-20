using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppServices.Interfaces;
using System.Collections.Generic;
using AppServices.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace AppServices
{
    public static class ServiceInjections
    {
        public static IServiceCollection AddServiceInjection(this IServiceCollection services)
        {
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IFacultyService, FacultyService>();
            services.AddScoped<IStudentService, StudentService>();

            return services;
        }
    }
}
