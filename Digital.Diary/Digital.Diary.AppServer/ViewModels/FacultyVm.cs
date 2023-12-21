using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Digital.Diary.AppServer.Models.Academic;
using Digital.Diary.AppServer.Services.Academic;
using System.Collections.ObjectModel;

namespace Digital.Diary.AppServer.ViewModels
{
    public partial class FacultyVm : BaseVm
    {
        private readonly IFacultyService _service;
        private int i = 0;

        public FacultyVm(IFacultyService service)
        {
            _service = service;
        }

        [ObservableProperty]
        private bool isRefreshing;

        [ObservableProperty]
        private ObservableCollection<Faculty> faculties;

        [RelayCommand]
        private async Task OnRefreshing()
        {
            IsRefreshing = true;

            try
            {
                await LoadDataAsync();
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        private string GetImagePathForFaculty(Faculty faculty)
        {
            //string imageName = faculty.Identifier.ToString().ToLower();
            int index = (int)i % imageNames.Count;
            i += 1;
            return $"Images/{imageNames[index]}";
        }

        public async Task LoadDataAsync()
        {
            var facultiesData = await _service.GetFacultyAsync();

            foreach (var faculty in facultiesData)
            {
                faculty.ImagePath = GetImagePathForFaculty(faculty);
            }

            Faculties = new ObservableCollection<Faculty>(facultiesData);
            //Faculties = new ObservableCollection<Faculty>(await _service.GetFacultyAsync());
        }

        private List<string> imageNames = new List<string>
        {
            "engineeringfaculty",
            "sciencefaculty",
            "biologyfaculty",
            "businessfaculty",
            "socialscience_faculty",
            "humanitiesfaculty",
            "lawfaculty",
            "agriculturefaculty"
        };
    }
}