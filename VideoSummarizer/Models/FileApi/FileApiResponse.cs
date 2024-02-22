using System.Text.Json;
using System.Text.Json.Serialization;

namespace VideoSummarizer.Models.FileApi
{
    public class FileApiResponse
    {
        [JsonPropertyName("media")]
        public FileMedia Media { get; set; }

        [JsonConstructor]
        public FileApiResponse(FileMedia media)
        {
            Media = media;
        }

        public static FileApiResponse FromJson(string json)
        {
            FileApiResponse? response = JsonSerializer.Deserialize<FileApiResponse>(json);

            if(response == null)
                throw new JsonException($"Failed to deserialize FileApiResponse from json:\n{json}");

            return response;
        }
    }
}
