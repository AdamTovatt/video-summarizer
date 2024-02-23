using Microsoft.AspNetCore.Mvc;
using VideoSummarizer.Helpers;
using VideoSummarizer.Models;
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
            using (Stream videoStream = await VideoDownloader.Instance.GetVideoStreamAsync(fileInfo.Media.DefaultFileSource.Url))
            {
                SpeechToTextResponse speechToTextResponse = await WhisperHelper.Instance.SpeechToText(videoStream);

                return Ok(speechToTextResponse.Text);
            }
        }
    }
}
