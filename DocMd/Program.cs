using Microsoft.VisualBasic;

namespace DocMd
{
    class Program
    {
        static void Main()
        {
            string variableName = "certkeywern";
            string secret = Environment.GetEnvironmentVariable(variableName);

            Console.WriteLine("Please provide the path to the solution, or project folder" +
                "you wish to document");

            var filePath = Console.ReadLine();
            try
            {
                DirectoryTraverser traverser = new DirectoryTraverser();
                var sourceFileInfo = traverser.Traverse(new DirectoryInfo(filePath));

                var systemInstructions = MessagingConstants.SystemInstructions;

                var apiKey = "your-api-key"; // Replace with your actual API key
                var client = new OpenAIClient(secret);

                string result = client.CallOpenAiApiAsync(systemInstructions + sourceFileInfo).Result;
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