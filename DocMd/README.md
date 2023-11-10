# DocMD: Documentation

## Namespace: DocMd

### DirectoryTraverser.cs
This class is responsible for traversing through the directories and processing all C# files.

- **Traverse(DirectoryInfo directoryInfo)**: This method starts the process of traversing through the directories.
- **ProcessDirectory(DirectoryInfo directoryInfo)**: This method recursively processes all C# files in the directory and its subdirectories.

### FileProcessor.cs
This static class processes individual files and extracts namespaces.

- **ProcessFile(FileInfo file)**: Reads the content of the file, extracts the namespace, and returns a `SourceFileInfo` object.
- **ExtractNamespace(string fileContent)**: Uses regular expressions to extract the namespace from the file content.

### Message.cs
This class represents a message with properties for role and content.

### MessagingConstants.cs
This class holds a constant string message used for system instructions.

## Namespace: 

### OpenAIClient.cs
This class is responsible for making API calls to the OpenAI API.

- **CallOpenAiApiAsync(List<SourceFileInfo> sourceFileInfoCollection)**: This method prepares a request to the OpenAI API, sends it, and returns the response.

### PromptMessage.cs
This class represents a prompt message with properties for system instructions and code.

## Business Logic

1. The `DirectoryTraverser` class traverses through the directories and processes all C# files in the directory and its subdirectories.
2. The `FileProcessor` class processes individual files, reads their content, and extracts namespaces.
3. The `OpenAIClient` class makes an API call to the OpenAI API with the processed files and returns the response.
4. The `Program` class gets the path to the solution or project folder and the name of the project from the user, uses the `DirectoryTraverser` to traverse the directories, uses the `OpenAIClient` to make the API call, and writes the result to a markdown file.
5. The `Message` and `PromptMessage` classes represent messages with properties for role and content, and system instructions and code, respectively.
6. The `MessagingConstants` class holds a constant string message used for system instructions.