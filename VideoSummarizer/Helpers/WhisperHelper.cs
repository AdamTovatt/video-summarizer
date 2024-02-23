using Microsoft.OpenApi.Exceptions;
using VideoSummarizer.Models;

namespace VideoSummarizer.Helpers
{
    public class WhisperHelper
    {
        public static WhisperHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new WhisperHelper();
                return _instance;
            }
        }

        private static WhisperHelper? _instance;

        private HttpClient http;

        public WhisperHelper()
        {
            http = CreateHttpClient();
        }

        public async Task<SpeechToTextResponse> SpeechToText(byte[] audioBytes)
        {
            string whisperUrl = "https://api.openai.com/v1/audio/transcriptions";

            using (MultipartFormDataContent content = new MultipartFormDataContent())
            {
                content.Add(new ByteArrayContent(audioBytes), "file", "audio.mp4");
                content.Add(new StringContent("whisper-1"), "model");

                HttpResponseMessage response = await http.PostAsync(whisperUrl, content);
                string json = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new Exception(json);

                return SpeechToTextResponse.FromJson(json);
            }
        }

        public async Task<SpeechToTextResponse> SpeechToText(Stream audioStream)
        {
            string whisperUrl = "https://api.openai.com/v1/audio/transcriptions";

            using (MultipartFormDataContent content = new MultipartFormDataContent())
            {
                content.Add(new StreamContent(audioStream), "file", "audio.mp4");
                content.Add(new StringContent("whisper-1"), "model");

                HttpResponseMessage response = await http.PostAsync(whisperUrl, content);
                string json = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new Exception(json);

                return SpeechToTextResponse.FromJson(json);
            }
        }

        public static byte[] IFormFileToByte(IFormFile formFile)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                formFile.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        private HttpClient CreateHttpClient()
        {
            HttpClient result = new HttpClient();
            string? apiKey = Environment.GetEnvironmentVariable("OPEN_AI_API_KEY");

            if (apiKey == null)
                throw new ArgumentNullException("missing open AI API key");

            result.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);
            return result;
        }
    }
}
