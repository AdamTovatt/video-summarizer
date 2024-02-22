namespace VideoSummarizer.Helpers
{
    public interface IVideoDownloader
    {
        public Task<Stream> GetVideoStreamAsync(string fileUrl);
    }
}
