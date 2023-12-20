using Digital.Diary.AppServer.Models.Academic;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Digital.Diary.AppServer.Services.Academic
{
    public class FacultyService : IFacultyService
    {
        private readonly HttpClient _httpClient;
        private const string BaseAddress = "https://61vf52vz-5116.inc1.devtunnels.ms/api/Faculty/GetAll";
        private readonly List<Faculty> faculties;

        public FacultyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            faculties = new List<Faculty>();
        }

        public async Task<IEnumerable<Faculty>> GetFacultyAsync()
        {
            var result = await _httpClient.GetAsync(BaseAddress);
            var response = await result.Content.ReadFromJsonAsync<List<Faculty>>();
            return response;
        }
    }
}