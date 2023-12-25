using Digital.Diary.AppServer.ViewModels.Administation;

namespace Digital.Diary.AppServer.Pages.HomePages;

public partial class AdministratrixPage : ContentPage
{
    private readonly OfficeVm _officeVm;

    public AdministratrixPage(OfficeVm officeVm)
    {
        InitializeComponent();
        _officeVm = officeVm;
        BindingContext = _officeVm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _officeVm.LoadDataAsync();
    }
}