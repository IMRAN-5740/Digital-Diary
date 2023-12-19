using Digital.Diary.AppServer.Models.Academic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.AppServer.Services.Academic
{
    public interface IFacultyService
    {
        Task<IEnumerable<FacultyAppModel>> GetFacultyAsync();

        Task<FacultyAppModel> GotoFacultyByIdAsync(string id);
    }
}