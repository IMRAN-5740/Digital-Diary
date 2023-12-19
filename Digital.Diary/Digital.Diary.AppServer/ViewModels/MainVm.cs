using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Digital.Diary.AppServer.Models.Academic;
using Digital.Diary.AppServer.Services.Academic;
using Digital.Diary.AppServer.Views.Academic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.AppServer.ViewModels
{
    public partial class MainVm : BaseVm
    {
        private readonly IFacultyService _facultyService;

        public MainVm(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        [ObservableProperty]
        private bool isRefreshing;

        [ObservableProperty]
        private ObservableCollection<FacultyAppModel> faculties;

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
            Faculties = new ObservableCollection<FacultyAppModel>(await _facultyService.GetFacultyAsync());
        }

        [RelayCommand]
        private async void GoToDetail(FacultyAppModel entity)
        {
            await Shell.Current.GoToAsync($"{nameof(FacultyDetailPage)}?Id={entity.Id}");
        }
    }
}