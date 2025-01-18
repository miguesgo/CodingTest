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
            return JsonSerializer.Deserialize<List<int>>(json)!;
        }

        public async Task<HackerNew> GetStoryById(int id)
        {
            var response = await _httpClient.GetAsync($"item/{id}.json");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<HackerNew>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // Ignora las diferencias entre mayúsculas y minúsculas
            })!;
        }

        public async Task<List<HackerNew>> GetStoryDetail(int count)
        {
            // Obtener los IDs de las historias
            var storyIds = await GetBestStoriesIdsAsync();

            // Limitar la cantidad a procesar según `count`
            var topStoryIds = storyIds.Take(count);

            // Obtener los detalles de las historias en paralelo
            var stories = await Task.WhenAll(topStoryIds.Select(id => GetStoryById(id)));

            // Retornar como lista
            return stories.ToList();
        }
    }
}
