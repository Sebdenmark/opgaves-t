using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace objekt_dag_1
{
    public class WordCounter
    {
        // method to count the word 
        public int CountOccurrences(string text, string word)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(word))
            {
                return 0; 
            }

            // here we split the text op in words, so we can count the given word 
            int count = 0;
            string[] words = text.Split(new[] { ' ', '\n', '\r', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string w in words)
            {
                if (w.Equals(word, StringComparison.OrdinalIgnoreCase)) 
                {
                    count++;
                }
            }

            return count;
        }
    }
}
