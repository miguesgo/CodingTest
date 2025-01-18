using System.Text.Json;

namespace CodingTest.HackerNew
{
    public class HackerNewService : HackerNewInterface
    {
        private readonly HttpClient _httpClient;

        public HackerNewService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<int>> GetBestStoriesIdsAsync()
        {
            var response = await _httpClient.GetAsync("beststories.json");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<int>>(json);
        }
    }
}
