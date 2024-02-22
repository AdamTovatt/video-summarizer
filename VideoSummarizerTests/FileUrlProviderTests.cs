using VideoSummarizer.Helpers;
using VideoSummarizer.Models.FileApi;

namespace VideoSummarizerTests
{
    [TestClass]
    public class FileUrlProviderTests
    {
        const string videoPageUrl = "https://lu.instructuremedia.com/embed/4995f6bb-ef4e-47ac-9eb7-8700c84a194c";

        [TestMethod]
        public async Task CanConvertFileUrl()
        {
            FileApiResponse apiRespone = await FileInfoProvider.Instance.GetFileInfoAsync(videoPageUrl);

            Assert.AreEqual(3, apiRespone.Media.Sources.Count);
            Assert.IsTrue(apiRespone.Media.Sources.All(x => x.Url.Length > 0));
        }
    }
}