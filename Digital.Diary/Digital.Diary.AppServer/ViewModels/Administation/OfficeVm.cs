using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Digital.Diary.AppServer.Models.Administration;
using Digital.Diary.AppServer.Services.Administration;
using System.Collections.ObjectModel;

namespace Digital.Diary.AppServer.ViewModels.Administation
{
    public partial class OfficeVm : BaseVm
    {
        private readonly IOfficeService _service;
        private int i = 0;

        public OfficeVm(IOfficeService service)
        {
            _service = service;
        }

        [ObservableProperty]
        private bool isRefreshing;

        [ObservableProperty]
        private ObservableCollection<Office> offices;

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

        private string GetImagePathForFaculty(Office office)
        {
            int index = (int)i % imageNames.Count;
            i += 1;
            return $"Images/faculties/{imageNames[index]}";
        }

        public async Task LoadDataAsync()
        {
            var officesData = await _service.GetOfficeAsync();

            foreach (var off in officesData)
            {
                off.ImagePath = GetImagePathForFaculty(off);
            }

            Offices = new ObservableCollection<Office>(officesData);
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
        private async void GoToDepartments(Office office)
        {
            await Shell.Current.GoToAsync($"DepartmentPage", true,
                new Dictionary<string, object>
                {
                    {
                        "Office",office
                    }
                });
        }
    }
}