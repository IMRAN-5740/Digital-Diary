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

        public async Task LoadDataAsync()
        {
            Faculties = new ObservableCollection<Faculty>(await _service.GetFacultyAsync());
        }
    }
}