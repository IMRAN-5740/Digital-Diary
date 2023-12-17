namespace Digital.Diary.AppServer
{
    public partial class MainPage : ContentPage
    {
        private readonly HttpClient _httpClient = new();
        private const string BaseAddress = "https://61vf52vz-5116.inc1.devtunnels.ms";

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var resultJson = await _httpClient.GetStringAsync($"{BaseAddress}/api/Department/GetAll/");
            weatherResult.Text = resultJson;
        }
    }
}