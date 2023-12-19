using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Digital.Diary.AppServer.Models.Academic;
using Digital.Diary.AppServer.Services.Academic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.AppServer.ViewModels
{
    [QueryProperty(nameof(Id), "Id")]
    public partial class FacultyDetailVm : BaseVm
    {
        private readonly IFacultyService _faultyService;

        public FacultyDetailVm(IFacultyService facultyService)
        {
            _faultyService = facultyService;
        }

        [ObservableProperty]
        private string id;

        [ObservableProperty]
        private FacultyAppModel faculty;

        public async Task LoadFacultyDataByIdAsync()
        {
            Faculty = await _faultyService.GotoFacultyByIdAsync(Id);
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}