using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace SimpleTextProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            TextProcessor textProcessor = new TextProcessor();
            textProcessor.ProcessingCompleted += TextProcessor_ProcessingCompleted;

            Console.WriteLine("Enter the path of the text file:");
            string filePath = Console.ReadLine();

            textProcessor.ProcessText(filePath);
        }

        private static void TextProcessor_ProcessingCompleted(object sender, TextProcessedEventArgs e)
        {
            Console.WriteLine($"Total number of words: {e.WordCount}");
            Console.WriteLine("Character frequencies:");
            foreach (var kvp in e.CharFrequency)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            Console.WriteLine($"Longest word: {e.LongestWord}");
        }
    }
}
