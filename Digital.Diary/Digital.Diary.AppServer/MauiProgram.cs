﻿using Digital.Diary.AppServer.Services.Academic;
using Digital.Diary.AppServer.ViewModels;
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

            //Services
            builder.Services.AddTransient<HttpClient>();
            builder.Services.AddTransient<IFacultyService, FacultyService>();
            //ViewModels
            builder.Services.AddTransient<FacultyVm>();
            //pages
            builder.Services.AddTransient<MainPage>();
            return builder.Build();
        }
    }
}