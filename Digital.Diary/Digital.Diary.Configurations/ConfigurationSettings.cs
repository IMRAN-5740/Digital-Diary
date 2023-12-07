using Digital.Diary.Databases.Data;
using Digital.Diary.Repositories;
using Digital.Diary.Repositories.Abstractions;
using Digital.Diary.Services;
using Digital.Diary.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Digital.Diary.Configurations
{
    public class ConfigurationSettings
    {
        public static void ConfigurationResolve(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                string connectionString = "Server=MOHAMMAD-IMRAN\\SQLEXPRESS; Database=DigitalDiary; Integrated Security=True;MultipleActiveResultSets=True;Encrypt=False;Trust Server Certificate=True; User Id=IMRAN-5740;Password=imranS";
                options.UseSqlServer(connectionString);
            });

            //dependency resolving mechanisms

            services.AddTransient<IDesignationRepository, DesignationRepository>();
            services.AddTransient<IDesignationService, DesignationService>();

        }
    }
}
