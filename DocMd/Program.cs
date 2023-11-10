using Microsoft.VisualBasic;
using System.Text.Json;

namespace DocMd
{
    class Program
    {
        private static object projectName;

        static async Task Main()
        {
            string variableName = "certkeywern";
            string secret = Environment.GetEnvironmentVariable(variableName);

            Console.WriteLine("Please provide the path to the solution, or project folder" +
                " you wish to document");
            var filePath = Console.ReadLine();

            Console.WriteLine("Please provide the name of the project");
            var projectName = Console.ReadLine();

            try
            {
                DirectoryTraverser traverser = new DirectoryTraverser();
                var sourceFileInfo = traverser.Traverse(new DirectoryInfo(filePath));
                var client = new OpenAIClient(secret);

                string result = await client.CallOpenAiApiAsync(sourceFileInfo);

                File.WriteAllText($"C:\\DocMd\\{projectName}Doc.md", result);

                Console.WriteLine(result);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Any key to exit");
        }
    }
}