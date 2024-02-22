using Microsoft.AspNetCore.Mvc;
using VideoSummarizer.Helpers;
using VideoSummarizer.Models.FileApi;

namespace VideoSummarizer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SummaryController : ControllerBase
    {
        [HttpGet]
        public async Task<ObjectResult> GetSummaryAsync(string videoPageUrl)
        {
            FileApiResponse fileInfo = await FileInfoProvider.Instance.GetFileInfoAsync(videoPageUrl);

            return Ok(fileInfo.Media.ThumbnailUrl);
        }
    }
}
