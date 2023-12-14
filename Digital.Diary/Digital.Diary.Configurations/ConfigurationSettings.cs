using Digital.Diary.Repositories.Abstractions.Academic;
using Digital.Diary.Repositories.Abstractions.Administration.Associations;
using Digital.Diary.Repositories.Academic;
using Digital.Diary.Repositories.Administration.Associations;
using Digital.Diary.Services.Abstractions.Academic;
using Digital.Diary.Services.Abstractions.Administration.Associations;
using Digital.Diary.Services.Academic;
using Digital.Diary.Services.Administration.Associations;
using Digital.Diary.Services.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Digital.Diary.Configurations
{
    public class ConfigurationSettings
    {
        public static void ConfigurationResolve(IServiceCollection services)
        {
            //dependency resolving mechanisms

            #region Academic
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

            services.AddTransient<IStaffRepository, StaffRepository>();
            services.AddTransient<IStaffService, StaffService>();

            services.AddTransient<ICrTableRepository, CrTableRepository>();
            services.AddTransient<ICrTableService, CrTableService>();

            #endregion  Academic
            #region Administration

            services.AddTransient<IAssociationRepository, AssociationRepository>();
            services.AddTransient<IAssociationService, AssociationService>();

            services.AddTransient<IAssociationEmployeeRepository, AssociationEmployeeRepository>();
            services.AddTransient<IAssociationEmployeeService, AssociationEmployeeService>();

            #endregion Administration

            

        }
    }
}