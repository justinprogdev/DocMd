using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class OpenAIClient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _apiUrl = "https://api.openai.com/v1/engines/davinci/completions";

    public OpenAIClient(string apiKey)
    {
        _httpClient = new HttpClient();
        _apiKey = apiKey;
    }

    public async Task<string> CallOpenAiApiAsync(string prompt)
    {
        var requestBody = new
        {
            prompt = prompt,
            max_tokens = 150
        };

        var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);

        var response = await _httpClient.PostAsync(_apiUrl, content);

        if (response.IsSuccessStatusCode)
        {
            string resultContent = await response.Content.ReadAsStringAsync();
            return resultContent;
        }
        else
        {
            // Error handling here
            throw new HttpRequestException($"Error calling OpenAI API: {response.StatusCode}");
        }
    }
}