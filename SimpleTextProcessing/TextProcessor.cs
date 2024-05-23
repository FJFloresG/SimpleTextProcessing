using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpleTextProcessing
{
    public class TextProcessor
    {
        internal Action<object, TextProcessedEventArgs> ProcessingCompleted { get; set; }


        public void ProcessText(string filePath)
        {
            try
            {
                string text = ReadTextFromFile(filePath);

                if (string.IsNullOrWhiteSpace(text))
                {
                    throw new Exception("File is empty or contains only whitespace.");
                }

                int wordCount = CountWords(text);
                Dictionary<char, int> charFrequency = CalculateCharFrequency(text);
                string longestWord = FindLongestWord(text);

                OnProcessingCompleted(new TextProcessedEventArgs(wordCount, charFrequency, longestWord));
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private string ReadTextFromFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        private int CountWords(string text)
        {
            return text.Split(new[] { ' ', '\n', '\r', '\t', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        private Dictionary<char, int> CalculateCharFrequency(string text)
        {
            return text.Where(c => !char.IsWhiteSpace(c))
                       .GroupBy(c => c)
                       .ToDictionary(g => g.Key, g => g.Count());
        }

        private string FindLongestWord(string text)
        {
            return text.Split(new[] { ' ', '\n', '\r', '\t', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                       .OrderByDescending(word => word.Length)
                       .FirstOrDefault();
        }

        protected virtual void OnProcessingCompleted(TextProcessedEventArgs e)=> ProcessingCompleted?.Invoke(this, e);
        }
       
}
