namespace CodingTest.HackerNew
{
    public interface HackerNewInterface
    {
        Task<List<int>> GetStories();

        Task<HackerNew> GetStoryById(int id);

        Task<List<HackerNew>> GetStoriesDetail(int count);
    }
}
