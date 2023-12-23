using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Digital.Diary.AppServer.Models.Academic;
using Digital.Diary.AppServer.Services.Academic;
using System;
using System.Collections.ObjectModel;

namespace Digital.Diary.AppServer.ViewModels
{
    [QueryProperty(nameof(Faculty), "Faculty")]
    public partial class DepartmentVm : BaseVm
    {
        private readonly IDepartmentService _service;
        private int i = 0;

        public DepartmentVm(IDepartmentService service)
        {
            _service = service;
        }

        [ObservableProperty]
        private Faculty faculty;

        [ObservableProperty]
        private bool isRefreshing;

        [ObservableProperty]
        private ObservableCollection<Department> departments;

        [RelayCommand]
        private async Task OnRefreshing()
        {
            IsRefreshing = true;
            try
            {
                await LoadDepartmentByFacultyIdAsync();
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        private string GetImagePathForDepartment(Department dept)
        {
            int index = 0;
            string imageName = null;
            if (faculty.ShortName == "engineering")
            {
                index = (int)i % engIcons.Count;
                i += 1;
                imageName = $"Images/Engineeringfaculty/{engIcons[index]}";
            }
            else if (faculty.ShortName == "science")
            {
                index = (int)i % scienceIcons.Count;
                i += 1;
                imageName = $"Images/sciencefaculty/{scienceIcons[index]}";
            }
            else if (faculty.ShortName == "biology")
            {
                index = (int)i % biologyIcons.Count;
                i += 1;
                imageName = $"Images/biologyfaculty/{biologyIcons[index]}";
            }
            else if (faculty.ShortName == "business")
            {
                index = (int)i % businessIcons.Count;
                i += 1;
                imageName = $"Images/businessfaculty/{biologyIcons[index]}";
            }
            else if (faculty.ShortName == "society")
            {
                index = (int)i % socialIcons.Count;
                i += 1;
                imageName = $"Images/socialsciencefaculty/{socialIcons[index]}";
            }
            else if (faculty.ShortName == "humanities")
            {
                index = (int)i % humanitiesIcons.Count;
                i += 1;
                imageName = $"Images/humanitiesfaculty/{humanitiesIcons[index]}";
            }
            else if (faculty.ShortName == "law")
            {
                index = (int)i % lawIcons.Count;
                i += 1;
                imageName = $"Images/lawfaculty/{lawIcons[index]}";
            }
            else if (faculty.ShortName == "agriculture")
            {
                index = (int)i % agriIcons.Count;
                i += 1;
                imageName = $"Images/agriculturefaculty/{agriIcons[index]}";
            }

            return imageName;
        }

        public async Task LoadDepartmentByFacultyIdAsync()
        {
            var departmentData = await _service.GetDepartmentByFacultyAsync(faculty);
            foreach (var fact in departmentData)
            {
                fact.ImagePath = GetImagePathForDepartment(fact);
            }

            Departments = new ObservableCollection<Department>(departmentData);
        }

        #region Engineering Faculty

        private List<string> engIcons = new List<string>
        {
            "cse.png",
            "eee.png",
            "acce.png",
            "ce.png",
            "fe.png",
            "architect.png"
        };

        #endregion Engineering Faculty

        #region Science Faculty

        private List<string> scienceIcons = new List<string>
        {
            "math",
            "stat",
            "chemistry",
            "phy",
            "esd",
        };

        #endregion Science Faculty

        #region Biology Faculty

        private List<string> biologyIcons = new List<string>
        {
            "pharmacy",
            "bmb",
            "genetic",
            "psy",
            "botany",
        };

        #endregion Biology Faculty

        #region Social Science Faculty

        private List<string> socialIcons = new List<string>
        {
            "eco",
            "soc",
            "pad",
            "ir",
            "ps",
        };

        #endregion Social Science Faculty

        #region Business Faculty

        private List<string> businessIcons = new List<string>
        {
            "management",
            "ais",
            "mgt",
            "fb",
            "thm",
        };

        #endregion Business Faculty

        #region Humanities Faculty

        private List<string> humanitiesIcons = new List<string>
        {
            "english",
            "bangla",
            "history",
        };

        #endregion Humanities Faculty

        #region Law Faculty

        private List<string> lawIcons = new List<string>
        {
            "lawdept",
        };

        #endregion Law Faculty

        #region Agriculture Faculty

        private List<string> agriIcons = new List<string>
        {
            "agri",
            "fmb",
            "asvm",
        };

        #endregion Agriculture Faculty
    }
}