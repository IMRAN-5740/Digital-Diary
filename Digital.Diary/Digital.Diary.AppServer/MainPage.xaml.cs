using Digital.Diary.AppServer.Models.Academic;
using Digital.Diary.AppServer.ViewModels;
using System.Collections.ObjectModel;

namespace Digital.Diary.AppServer
{
    public partial class MainPage : ContentPage
    {
        private readonly HttpClient _httpClient = new();
        private const string BaseAddress = "https://61vf52vz-5116.inc1.devtunnels.ms";
        public MainVm MainVm { get; }

        public MainPage(MainVm mainVm)
        {
            InitializeComponent();
            BindingContext = MainVm = mainVm;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await MainVm.LoadDataAsync();
        }

        //private async void counterButton_Clicked(object sender, EventArgs e)
        //{
        //    var resultJson = await _httpClient.GetStringAsync($"{BaseAddress}/api/Department/GetAll/");
        //    weatherResult.Text = resultJson;
        //}
    }
}