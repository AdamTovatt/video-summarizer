using System.Text.Json.Serialization;

namespace VideoSummarizer.Models.FileApi
{
    public class FileMedia
    {
        [JsonPropertyName("sources")]
        public List<FileSource> Sources { get; set; }

        [JsonPropertyName("duration")]
        public float Duration { get; set; }

        [JsonPropertyName("thubmnail_url")]
        public string ThumbnailUrl { get; set; }

        [JsonIgnore]
        public FileSource DefaultFileSource { get => GetDefaultFileSource(); }

        [JsonConstructor]
        public FileMedia(List<FileSource> sources, float duration, string thumbnailUrl)
        {
            Sources = sources;
            Duration = duration;
            ThumbnailUrl = thumbnailUrl;
        }

        private FileSource GetDefaultFileSource()
        {
            FileSource? result = Sources.FirstOrDefault(x => x.Definition == "low");

            if(result != null)
                return result;

            return Sources[0];
        }
    }
}
