namespace CodingTest.HackerNew
{
    public interface HackerNewInterface
    {
        Task<List<int>> GetBestStoriesIdsAsync();

        Task<HackerNew> GetStoryById(int id);

        Task<List<HackerNew>> GetStoryDetail(int count);
    }
}
