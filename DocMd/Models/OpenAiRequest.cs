internal class OpenAiRequest
{
    public string Model { get; set; }
    public Message[] Messages { get; set; }
}