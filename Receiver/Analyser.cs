using System.Collections.Generic;

namespace Receiver
{
    public class Analyser
    {
        public static IEnumerable<string> GetSeparatedWordsBySpaceFromARow(IEnumerable<string> row)
        {
            var separatedRow = new List<string>();
            foreach (var item in row)
            {
                var words = item.Split(' ');
                foreach (var word in words) separatedRow.Add(word);
            }

            return separatedRow;
        }

        public static IDictionary<string, int> AddWordCountInDictionary(IDictionary<string, int> wordfrequency,
            IEnumerable<string> wordsInRow)
        {
            foreach (var word in wordsInRow)
                if (!wordfrequency.ContainsKey(word))
                    wordfrequency.Add(word, 1);
                else
                    wordfrequency[word]++;
            return wordfrequency;
        }

        public IDictionary<string, int> CountWordFrequency(IEnumerable<IEnumerable<string>> data)
        {
            IDictionary<string, int> wordfrequency = new Dictionary<string, int>();

            foreach (List<string> row in data)
            {
                var wordsInARow = GetSeparatedWordsBySpaceFromARow(row);
                wordfrequency = AddWordCountInDictionary(wordfrequency, wordsInARow);
            }

            return wordfrequency;
        }
    }
}