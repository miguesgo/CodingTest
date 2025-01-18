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

        [HttpGet("GetStoryDetail")]
        public async Task<IActionResult> GetStoryDetail([FromQuery] int count = 5)
        {
            var stories = await _hackerNewInterface!.GetStoriesDetail(count);
            IEnumerable<HackerNew> query = stories.OrderByDescending(story => story.Score);
            return Ok(query);
        }
    }
}
