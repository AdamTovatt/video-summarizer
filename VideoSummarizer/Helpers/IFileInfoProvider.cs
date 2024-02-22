using VideoSummarizer.Models.FileApi;

namespace VideoSummarizer.Helpers
{
    public interface IFileInfoProvider
    {
        public Task<FileApiResponse> GetFileInfoAsync(string videoPageUrl);
    }
}
