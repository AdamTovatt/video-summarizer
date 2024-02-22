using System.Text.Json.Serialization;

namespace VideoSummarizer.Models.FileApi
{
    public class FileSource
    {
        [JsonPropertyName("mime_type")]
        public string MimeType { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("definition")]
        public string Definition { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonConstructor]
        public FileSource(string mimeType, string url, string definition, string status)
        {
            MimeType = mimeType;
            Url = url.Trim();
            Definition = definition;
            Status = status;
        }
    }
}
