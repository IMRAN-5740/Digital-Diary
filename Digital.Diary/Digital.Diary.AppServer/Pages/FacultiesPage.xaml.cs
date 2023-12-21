using Digital.Diary.AppServer.ViewModels;

namespace Digital.Diary.AppServer.Pages;

public partial class FacultiesPage : ContentPage
{
    private readonly FacultyVm _factVm;

    public FacultiesPage(FacultyVm factVm)
    {
        InitializeComponent();
        _factVm = factVm;
        BindingContext = _factVm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _factVm.LoadDataAsync();
    }
}