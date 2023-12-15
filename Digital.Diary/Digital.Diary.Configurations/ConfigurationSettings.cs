using Digital.Diary.Repositories.Abstractions.Academic;
using Digital.Diary.Repositories.Abstractions.Administration.Associations;
using Digital.Diary.Repositories.Abstractions.Administration.Committees;
using Digital.Diary.Repositories.Abstractions.Administration.Offices;
using Digital.Diary.Repositories.Abstractions.Administration.Transportations;
using Digital.Diary.Repositories.Abstractions.Emergency_Services;
using Digital.Diary.Repositories.Abstractions.Miscellaneous;
using Digital.Diary.Repositories.Abstractions.Student_Activities.Clubs;
using Digital.Diary.Repositories.Academic;
using Digital.Diary.Repositories.Administration.Associations;
using Digital.Diary.Repositories.Administration.Committees;
using Digital.Diary.Repositories.Administration.Offices;
using Digital.Diary.Repositories.Administration.Transportation;
using Digital.Diary.Repositories.Emergency_Services;
using Digital.Diary.Repositories.Miscellaneous;
using Digital.Diary.Repositories.Student_Activities.Clubs;
using Digital.Diary.Services.Abstractions.Academic;
using Digital.Diary.Services.Abstractions.Administration.Associations;
using Digital.Diary.Services.Abstractions.Administration.Committees;
using Digital.Diary.Services.Abstractions.Administration.Offices;
using Digital.Diary.Services.Abstractions.Administration.Transportation;
using Digital.Diary.Services.Abstractions.Emergency_Services;
using Digital.Diary.Services.Abstractions.Miscellaneous;
using Digital.Diary.Services.Abstractions.Student_Activities.Clubs;
using Digital.Diary.Services.Academic;
using Digital.Diary.Services.Administration.Associations;
using Digital.Diary.Services.Administration.Committees;
using Digital.Diary.Services.Administration.Offices;
using Digital.Diary.Services.Administration.Transportation;
using Digital.Diary.Services.Emergency_Services;
using Digital.Diary.Services.Miscellaneous;
using Digital.Diary.Services.Student_Activities.Clubs;
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

            #endregion Academic

            #region Administration

            services.AddTransient<IAssociationRepository, AssociationRepository>();
            services.AddTransient<IAssociationService, AssociationService>();

            services.AddTransient<IAssociationEmployeeRepository, AssociationEmployeeRepository>();
            services.AddTransient<IAssociationEmployeeService, AssociationEmployeeService>();

            services.AddTransient<IOfficeRepository, OfficeRepository>();
            services.AddTransient<IOfficeService, OfficeService>();

            services.AddTransient<IOfficeEmployeeRepository, OfficeEmployeeRepository>();
            services.AddTransient<IOfficeEmployeeService, OfficeEmployeeService>();

            services.AddTransient<ICommitteeRepository, CommitteeRepository>();
            services.AddTransient<ICommitteeService, CommitteeService>();

            services.AddTransient<ICommitteeEmployeeRepository, CommitteeEmployeeRepository>();
            services.AddTransient<ICommitteeEmployeeService, CommitteeEmployeeService>();

            services.AddTransient<ITransportRepository, TransportRepository>();
            services.AddTransient<ITransportService, TransportService>();

            services.AddTransient<ITransportEmployeeRepository, TransportEmployeeRepository>();
            services.AddTransient<ITransportEmployeeService, TransportEmployeeService>();

            #endregion Administration

            #region Emergency Services

            services.AddTransient<IAmbulanceRepository, AmbulanceRepository>();
            services.AddTransient<IAmbulanceService, AmbulanceService>();

            services.AddTransient<IAnsarForceRepository, AnsarForceRepository>();
            services.AddTransient<IAnsarForceService, AnsarForceService>();

            services.AddTransient<IBusRepository, BusRepository>();
            services.AddTransient<IBusService, BusService>();

            services.AddTransient<ICourierRepository, CourierRepository>();
            services.AddTransient<ICourierService, CourierService>();

            services.AddTransient<IDistrictRepository, DistrictRepository>();
            services.AddTransient<IDistrictService, DistrictService>();

            services.AddTransient<IFireStationRepository, FireStationRepository>();
            services.AddTransient<IFireStationService, FireStationService>();

            services.AddTransient<IGuestHouseRepository, GuestHouseRepository>();
            services.AddTransient<IGuestHouseService, GuestHouseService>();

            services.AddTransient<IJournalistRepository, JournalistRepository>();
            services.AddTransient<IJournalistService, JournalistService>();

            services.AddTransient<IPoliceStationRepository, PoliceStationRepository>();
            services.AddTransient<IPoliceStationService, PoliceStationService>();

            services.AddTransient<IPostOfficeRepository, PostOfficeRepository>();
            services.AddTransient<IPostOfficeService, PostOfficeService>();

            services.AddTransient<ITrainRepository, TranRepository>();
            services.AddTransient<ITrainService, TrainService>();

            #endregion Emergency Services

            #region Miscellaneous

            services.AddTransient<IBankRepository, BankRepository>();
            services.AddTransient<IBankService, BankService>();

            services.AddTransient<IBankEmployeeRepository, BankEmployeeRepository>();
            services.AddTransient<IBankEmployeeService, BankEmployeeService>();

            #endregion Miscellaneous

            #region Student Activities

            services.AddTransient<IClubRepository, ClubRepository>();
            services.AddTransient<IClubService, ClubService>();

            services.AddTransient<IClubEmployeeRepository, ClubEmployeeRepository>();
            services.AddTransient<IClubEmployeeService, ClubEmployeeService>();

            #endregion Student Activities
        }
    }
}