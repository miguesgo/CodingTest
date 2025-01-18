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

        public async Task<List<int>> GetStories()
        {
            var response = await _httpClient.GetAsync("beststories.json");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<int>>(json)!;
        }

        public async Task<HackerNew> GetStoryById(int id)
        {
            var response = await _httpClient.GetAsync($"item/{id}.json");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<HackerNew>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        }

        public async Task<List<HackerNew>> GetStoriesDetail(int count)
        {
            var storyIds = await GetStories();
            var selectedStories = storyIds.Take(count);
            var details = await Task.WhenAll(selectedStories.Select(id => GetStoryById(id)));
            return details.ToList();
        }
    }
}
