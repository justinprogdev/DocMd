namespace DocMd.Constants
{
    internal class MessagingConstants
    {
        public static string SystemInstructions = "Here is a json structure. " +
            "It has code in it, name spaces, as well as file paths. " +
            "1. You must first comment all the business logic in a Business Logic section " +
            "that is easily understood and explains it's steps." +
            "2. You must generate documentation for the code in a concise way" +
            "3. We need as few words as possible while not ommiting important details." +
            "4. You must return it in markdown format, with proper headings, bullets and so on." +
            "5. Here is the code to analyze.. ->";
    }
}