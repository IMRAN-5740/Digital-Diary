using Digital.Diary.AppServer.ViewModels;

namespace Digital.Diary.AppServer
{
    public partial class MainPage : ContentPage
    {
        public FacultyVm fViewModel { get; }

        public MainPage(FacultyVm mainViewModel)
        {
            InitializeComponent();
            BindingContext = fViewModel = mainViewModel;
        }

        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            await fViewModel.LoadDataAsync();
        }
    }
}