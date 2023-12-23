using Digital.Diary.AppServer.Constants;
using Digital.Diary.AppServer.Models.Academic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.AppServer.Services.Academic
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DepartmentService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Department>> GetDepartmentByFacultyAsync(Faculty entity)
        {
            var httpClient = _httpClientFactory.CreateClient(AppConstants.HttpClientName);
            var response = await httpClient.GetAsync($"Faculty/{entity.Id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<Department>>();
                return result;
            }
            else
            {
                return Enumerable.Empty<Department>();
            }
        }
    }
}