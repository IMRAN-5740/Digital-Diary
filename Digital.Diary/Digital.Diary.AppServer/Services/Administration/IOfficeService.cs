using Digital.Diary.AppServer.Models.Academic;
using Digital.Diary.AppServer.Models.Administration;

namespace Digital.Diary.AppServer.Services.Administration
{
    public interface IOfficeService
    {
        Task<IEnumerable<Office>> GetOfficeAsync();
    }
}