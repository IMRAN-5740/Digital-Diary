using Digital.Diary.AppServer.Models.Academic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.AppServer.Services.Academic
{
    public class FacultyService : IFacultyService
    {
        private readonly List<FacultyAppModel> _listofFaculty;

        public FacultyService()
        {
            _listofFaculty = new List<FacultyAppModel>()
            {
                new FacultyAppModel
                {
                    Id="123",
                    FacultyName="ইঞ্জিনিয়ারিং অনুষদ",
                    ImageUrl="https://avatars.githubusercontent.com/u/89984763?v=4",
                    Description="This is Engineering Faculty"
                },
                new FacultyAppModel
                {
                     Id="456",
                    FacultyName="বিজ্ঞান অনুষদ",
                    ImageUrl="https://avatars.githubusercontent.com/u/89984763?v=4",
                },
                 new FacultyAppModel
                {
                      Id="883",
                    FacultyName="সামাজিক বিজ্ঞান অনুষদ",
                    ImageUrl="https://avatars.githubusercontent.com/u/89984763?v=4",
                },
                   new FacultyAppModel
                {
                        Id="6723",
                    FacultyName="আইন অনুষদ",
                    ImageUrl="https://avatars.githubusercontent.com/u/89984763?v=4",
                }
            };
        }

        public async Task<IEnumerable<FacultyAppModel>> GetFacultyAsync()
        {
            return _listofFaculty;
        }

        public async Task<FacultyAppModel> GotoFacultyByIdAsync(string id)
        {
            return _listofFaculty.Where(data => data.Id == id).FirstOrDefault();
        }
    }
}