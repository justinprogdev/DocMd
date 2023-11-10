using DocMd.Models;
using System.Text.RegularExpressions;

namespace DocMd
{
    internal static class FileProcessor
    {
        internal static SourceFileInfo ProcessFile(FileInfo file)
        {
            SourceFileInfo sourceFileInfo = new SourceFileInfo
            {
                FileText = File.ReadAllText(file.FullName),
                Namespace = ExtractNamespace(File.ReadAllText(file.FullName)),
                FilePath = file.FullName
            };

            
            Console.WriteLine("Processed file '{0}' with namespace '{1}'.", sourceFileInfo.FilePath, sourceFileInfo.Namespace);
            return sourceFileInfo;
        }

        internal static string ExtractNamespace(string fileContent)
        {
            var match = Regex.Match(fileContent, @"namespace\s+([^\s]+)");
            return match.Success ? match.Groups[1].Value : string.Empty;
        }
    }
}
