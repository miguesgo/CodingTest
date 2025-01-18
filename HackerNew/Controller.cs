using Microsoft.AspNetCore.Mvc;

namespace CodingTest.HackerNew
{
    [ApiController]
    [Route("api/stories")]
    public class Controller : ControllerBase
    {
        private readonly HackerNewInterface? _hackerNewInterface;

        public Controller(HackerNewInterface hackerNewInterface)
        {
            _hackerNewInterface = hackerNewInterface;
        }

        [HttpGet("beststories")]
        public async Task<IActionResult> GetBestStories()
        {
            var storyIds = await _hackerNewInterface!.GetBestStoriesIdsAsync();
            var stories = await Task.WhenAll(storyIds.Take(1).Select(id => _hackerNewInterface.GetStoryById(id)));
            return Ok(stories);
        }

        [HttpGet("beststories/detail")]
        public async Task<IActionResult> GetStoryDetail([FromQuery] int count = 5)
        {
            var stories = await _hackerNewInterface!.GetStoryDetail(count);

            IEnumerable<HackerNew> query = stories.OrderByDescending(story => story.Score);

            return Ok(query);
        }
    }
}
