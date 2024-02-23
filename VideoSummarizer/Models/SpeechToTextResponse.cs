using System.Text.Json.Serialization;
using System.Text.Json;

namespace VideoSummarizer.Models
{
    public class SpeechToTextResponse
    {
        [JsonPropertyName("text")]
        public string? Text { get; set; }

        public static SpeechToTextResponse FromJson(string json)
        {
            SpeechToTextResponse? response = JsonSerializer.Deserialize<SpeechToTextResponse>(json);

            if (response == null)
                throw new Exception($"Failed to deserialize SpeechToTextResponse from json:\n{json}");

            return response;
        }
    }
}
