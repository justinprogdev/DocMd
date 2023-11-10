using DocMd;
using DocMd.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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

            // "max_tokens": 512,
            //"top_p": 1,
            //"temperature": 0.5,
            //"frequency_penalty": 0,
            //"presence_penalty": 0

            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);

            var response = await _httpClient.PostAsync(_apiUrl, content);

            string resultContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ChatCompletionResponseModel>(resultContent)?.choices[0].message.content;
        }
    }
}
