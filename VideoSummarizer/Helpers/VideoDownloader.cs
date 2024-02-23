
namespace VideoSummarizer.Helpers
{
    public class VideoDownloader : IVideoDownloader
    {
        public static VideoDownloader Instance { get { if (instance == null) instance = new VideoDownloader(); return instance; } }

        private static VideoDownloader? instance;
        private HttpClient client;

        public VideoDownloader()
        {
            client = new HttpClient();
        }

        public Task<Stream> GetVideoStreamAsync(string fileUrl)
        {
            return client.GetStreamAsync(fileUrl);
        }
    }
}
