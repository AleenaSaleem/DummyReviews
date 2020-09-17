using System.Collections.Generic;

namespace Receiver
{
    public class Analyser
    {
        
        public static IEnumerable<string> GetSeparatedWordsBySpaceFromARow(IEnumerable<string> row)
        {
            List<string> separatedRow = new List<string>();
            foreach(var item in row)
            {
                string[] words = item.Split(' ');
                for(int i = 0; i < words.Length; i++)
                {
                    separatedRow.Add(words[i]);
                }
            }
            return separatedRow;
            
        }
        public static IDictionary<string,int> AddWordCountInDictionary(IDictionary<string,int> wordfrequency,IEnumerable<string> wordsInRow)
        {
            foreach(var word in wordsInRow)
            {
                if (!wordfrequency.ContainsKey(word))
                {
                    wordfrequency.Add(word, 1);
                }
                else
                {
                    wordfrequency[word]++;
                }
            }
            return wordfrequency;
        }
        public IDictionary<string, int> CountWordFrequency(IEnumerable<IEnumerable<string>> data)
        {
            IDictionary<string, int> Wordfrequency = new Dictionary<string, int>();

            foreach (List<string> row in data)
            {
                var wordsInARow = GetSeparatedWordsBySpaceFromARow(row);
                Wordfrequency = AddWordCountInDictionary(Wordfrequency, wordsInARow);
            }
            return Wordfrequency;

        }
    }
        
    
}
