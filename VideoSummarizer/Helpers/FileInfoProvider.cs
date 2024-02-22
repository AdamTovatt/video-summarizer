using VideoSummarizer.Models.FileApi;

namespace VideoSummarizer.Helpers
{
    public class FileInfoProvider : IFileInfoProvider
    {
        private const string fileApiUrl = "https://lu.instructuremedia.com/api/media_management/embed/{0}";

        public static FileInfoProvider Instance { get { if (instance == null) instance = new FileInfoProvider(); return instance; } }
        private static FileInfoProvider? instance;

        private HttpClient httpClient;

        public FileInfoProvider()
        {
            httpClient = new HttpClient();
        }

        public async Task<FileApiResponse> GetFileInfoAsync(string videoPageUrl)
        {
            Guid videoId = GetVideoId(videoPageUrl);
            string apiUrl = string.Format(fileApiUrl, videoId);

            HttpResponseMessage httpResponse = await httpClient.GetAsync(apiUrl);

            string response = await httpResponse.Content.ReadAsStringAsync();

            if (!httpResponse.IsSuccessStatusCode)
                throw new Exception($"Error when getting file url, status code: {httpResponse.StatusCode}, response: {response}");

            return FileApiResponse.FromJson(response);
        }

        private Guid GetVideoId(string videoPageUrl)
        {
            string[] parts = videoPageUrl.Split('/');

            if (Guid.TryParse(parts[parts.Length - 1], out Guid result))
                return result;

            throw new ArgumentException($"Invalid video page URL: {videoPageUrl}");
        }
    }
}
