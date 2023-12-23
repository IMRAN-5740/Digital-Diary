using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Digital.Diary.AppServer.Models.Academic;
using Digital.Diary.AppServer.Pages.Academic;
using Digital.Diary.AppServer.Services.Academic;
using Newtonsoft.Json;
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
            int index = (int)i % imageNames.Count;
            i += 1;
            return $"Images/faculties/{imageNames[index]}";
        }

        public async Task LoadDataAsync()
        {
            var facultiesData = await _service.GetFacultyAsync();

            foreach (var faculty in facultiesData)
            {
                faculty.ImagePath = GetImagePathForFaculty(faculty);
            }

            Faculties = new ObservableCollection<Faculty>(facultiesData);
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

        [RelayCommand]
        private async void GoToDepartments(Faculty faculty)
        {
            await Shell.Current.GoToAsync($"DepartmentPage", true,
                new Dictionary<string, object>
                {
                    {
                        "Faculty",faculty
                    }
                });
        }
    }
}