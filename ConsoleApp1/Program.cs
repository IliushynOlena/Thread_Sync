using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

class Program
{
    static async Task Main()
    {
        Console.Write("Enter the folder path: ");
        string folderPath = Console.ReadLine();

        Console.Write("Enter a word to search: ");
        string word = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
        {
            Console.WriteLine("Incorrect way to a directory.");
            return;
        }
        string[] files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

        int totalFiles = files.Length;
        int processed = 0;
        object lockObject = new object();

        Console.WriteLine($"\n {totalFiles} file(s) has been found. Starting a search...\n");

        var tasks = files.Select(async file =>
        {
            int count = 0;
            try
            {
                string text = await File.ReadAllTextAsync(file);
                count = CountWordOccurrences(text, word);

                lock (lockObject)
                {
                    Console.WriteLine($"Name of a file: {Path.GetFileName(file)}");
                    Console.WriteLine($"File path: {file}");
                    Console.WriteLine($"The amount of the searched word: {count}");
                    Console.WriteLine(new string('-', 40));
                    processed++;
                    Console.WriteLine($"Progress: {processed * 100 / totalFiles}%\n");
                }
            }
            catch
            {
            }
        });

        await Task.WhenAll(tasks);
        Console.WriteLine("The search has been ended.");
    }

    static int CountWordOccurrences(string text, string word)
    {
        return text.Split(new[] { ' ', '\r', '\n', '\t', '.', ',', ';', '!', '?', ':', '-', '\"' }, StringSplitOptions.RemoveEmptyEntries)
                   .Count(w => string.Equals(w, word, StringComparison.OrdinalIgnoreCase));
    }
}
