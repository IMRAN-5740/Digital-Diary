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

            services.AddTransient<IDeanRepository, DeanRepository>();
            services.AddTransient<IDeanService, DeanService>();

            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IDepartmentService, DepartmentService>();

            services.AddTransient<ICouncilRepository, CouncilRepository>();
            services.AddTransient<ICouncilService, CouncilService>();

            services.AddTransient<IRegentBoardRepository, RegentBoardRepository>();
            services.AddTransient<IRegentBoardService, RegentBoardService>();

            services.AddTransient<ITeacherRepository, TeacherRepository>();
            services.AddTransient<ITeacherService, TeacherService>();
        }
    }
}