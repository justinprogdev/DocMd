using DocMd.Models;

internal class PromptMessage
{
    public PromptMessage()
    {
    }

    public string SystemInstructions { get; set; }
    public List<SourceFileInfo> Code { get; set; }
}