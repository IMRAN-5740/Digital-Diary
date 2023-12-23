using Digital.Diary.AppServer.ViewModels;

namespace Digital.Diary.AppServer.Pages.Academic;

public partial class DepartmentPage : ContentPage
{
    private readonly DepartmentVm _deptVm;

    public DepartmentPage(DepartmentVm deptVm)
    {
        InitializeComponent();
        _deptVm = deptVm;
        BindingContext = _deptVm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _deptVm.LoadDepartmentByFacultyIdAsync();
    }
}