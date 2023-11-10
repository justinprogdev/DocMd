using System.Text.Json;
using System.Text.Json.Serialization;
using DocMd.Models;

namespace DocMd
{
    public class DirectoryTraverser
    {
        public List<SourceFileInfo> Traverse(DirectoryInfo directoryInfo)
        {
            return ProcessDirectory(directoryInfo);
        }

        private List<SourceFileInfo> ProcessDirectory(DirectoryInfo directoryInfo)
        {
            // Parse all C# files in the dir and process them
            FileInfo[] files = directoryInfo.GetFiles("*.cs");
            var sourceFileInfoCollection = new List<SourceFileInfo>();
            foreach (FileInfo file in files)
            {
                sourceFileInfoCollection.Add(FileProcessor.ProcessFile(file));
            }

            // recurse into all dirs
            DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();
            foreach (DirectoryInfo subdirectory in subDirectories)
                sourceFileInfoCollection.AddRange(ProcessDirectory(subdirectory));

            return sourceFileInfoCollection;
        }
    }
}
