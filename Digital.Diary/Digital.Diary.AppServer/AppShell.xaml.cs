using Digital.Diary.AppServer.Pages;
using Digital.Diary.AppServer.Pages.Academic;

namespace Digital.Diary.AppServer
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(FacultiesPage), typeof(FacultiesPage));
            Routing.RegisterRoute(nameof(DepartmentPage), typeof(DepartmentPage));
        }
    }
}