using DocMd.Constants;
using DocMd.Models;
using System.Text;
using System.Text.Json;

namespace DocMd
{

    public class OpenAIClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _apiUrl = "https://api.openai.com/v1/chat/completions";

        public OpenAIClient(string apiKey)
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey;
        }

        public async Task<string> CallOpenAiApiAsync(List<SourceFileInfo> sourceFileInfoCollection)
        {

            var promptMessage = new PromptMessage()
            {
                SystemInstructions = MessagingConstants.SystemInstructions,
                Code = sourceFileInfoCollection
            };

            var request = new
            {
                model = "gpt-4",
                messages = new[] { new Message { Role = "system", Content = JsonSerializer.Serialize(promptMessage) } },
                max_tokens = 500,
                temperature = 0.5,
            };

            var serializationOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            var content = new StringContent(JsonSerializer.Serialize(request, serializationOptions), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);

            var response = await _httpClient.PostAsync(_apiUrl, content);

            string resultContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ChatCompletionResponseModel>(resultContent)?.Choices[0].Message.Content;
        }
    }
}
