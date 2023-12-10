using Digital.Diary.Repositories;
using Digital.Diary.Repositories.Abstractions;
using Digital.Diary.Services;
using Digital.Diary.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Digital.Diary.Configurations
{
    public class ConfigurationSettings
    {
        public static void ConfigurationResolve(IServiceCollection services)
        {
            //dependency resolving mechanisms
            services.AddTransient<IDesignationRepository, DesignationRepository>();
            services.AddTransient<IDesignationService, DesignationService>();

            services.AddTransient<IFacultyRepository, FacultyRepository>();
            services.AddTransient<IFacultyService, FacultyService>();
        }
    }
}