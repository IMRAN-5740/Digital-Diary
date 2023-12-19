using Digital.Diary.AppServer.Views.Academic;

namespace Digital.Diary.AppServer
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(FacultyDetailPage), typeof(FacultyDetailPage));
        }
    }
}