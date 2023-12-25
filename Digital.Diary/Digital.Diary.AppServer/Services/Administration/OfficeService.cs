using Digital.Diary.AppServer.Constants;
using Digital.Diary.AppServer.Models.Administration;
using System;
using System.Net.Http.Json;

namespace Digital.Diary.AppServer.Services.Administration
{
    public class OfficeService : IOfficeService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OfficeService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Office>> GetOfficeAsync()
        {
            var httpClient = _httpClientFactory.CreateClient(AppConstants.HttpClientName);
            var response = await httpClient.GetAsync("Office/GetAll");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<Office>>();
                return result;
            }
            else
            {
                return Enumerable.Empty<Office>();
            }
        }
    }
}