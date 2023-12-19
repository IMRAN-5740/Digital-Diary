using Digital.Diary.AppServer.ViewModels;

namespace Digital.Diary.AppServer.Views.Academic;

public partial class FacultyDetailPage : ContentPage
{
    private FacultyDetailVm FacultyDetailVm;

    public FacultyDetailPage(FacultyDetailVm facultyDetailVm)
    {
        InitializeComponent();
        BindingContext = FacultyDetailVm = facultyDetailVm;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        FacultyDetailVm.LoadFacultyDataByIdAsync();
    }
}