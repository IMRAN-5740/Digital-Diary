using Digital.Diary.AppServer.Services.Academic;
using Digital.Diary.AppServer.ViewModels;
using Digital.Diary.AppServer.Views.Academic;
using Microsoft.Extensions.Logging;

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
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            //services
            builder.Services.AddSingleton<IFacultyService, FacultyService>();

            //viewModels
            builder.Services.AddSingleton<MainVm>();
            builder.Services.AddSingleton<FacultyDetailVm>();

            //pages
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<FacultyDetailPage>();

            return builder.Build();
        }
    }
}