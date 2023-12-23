using Digital.Diary.AppServer.Services.Academic;
using Digital.Diary.AppServer.ViewModels;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Digital.Diary.AppServer.Pages;
using Digital.Diary.AppServer.Pages.Academic;

namespace Digital.Diary.AppServer
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()

                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiCommunityToolkit();
            builder.Services.AddHttpClient(Constants.AppConstants.HttpClientName, httpClient =>
            {
                var baseAddress = "https://61vf52vz-5116.inc1.devtunnels.ms/api/";
                httpClient.BaseAddress = new Uri(baseAddress);
            });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            //Services
            builder.Services.AddTransient<HttpClient>();
            builder.Services.AddTransient<IFacultyService, FacultyService>();
            builder.Services.AddTransient<IDepartmentService, DepartmentService>();

            //ViewModels
            builder.Services.AddTransient<FacultyVm>();
            builder.Services.AddTransient<DepartmentVm>();
            //AddTransient
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<FacultiesPage>();
            builder.Services.AddTransient<DepartmentPage>();
            return builder.Build();
        }
    }
}