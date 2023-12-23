using Digital.Diary.AppServer.Constants;
using Digital.Diary.AppServer.Models.Academic;
using System.Net.Http.Json;

namespace Digital.Diary.AppServer.Services.Academic
{
    public class FacultyService : IFacultyService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FacultyService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Faculty>> GetFacultyAsync()
        {
            var httpClient = _httpClientFactory.CreateClient(AppConstants.HttpClientName);
            var response = await httpClient.GetAsync("Faculty/GetAll");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<Faculty>>();
                return result;
            }
            else
            {
                return Enumerable.Empty<Faculty>();
            }
        }
    }
}