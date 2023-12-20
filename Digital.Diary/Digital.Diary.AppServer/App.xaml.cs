using Digital.Diary.AppServer.ViewModels;
using Microsoft.Maui.Controls;

namespace Digital.Diary.AppServer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}