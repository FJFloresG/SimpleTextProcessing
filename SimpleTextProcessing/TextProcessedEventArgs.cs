using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTextProcessing
{
    internal class TextProcessedEventArgs:EventArgs
    {
        public int WordCount { get; }
        public Dictionary<char, int> CharFrequency { get; }
        public string LongestWord { get; }

        public TextProcessedEventArgs(int wordCount, Dictionary<char, int> charFrequency, string longestWord)
        {
            WordCount = wordCount;
            CharFrequency = charFrequency;
            LongestWord = longestWord;
        }
    }
}
