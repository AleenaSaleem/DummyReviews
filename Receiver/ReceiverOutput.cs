using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Receiver
{
    public interface IReceiverOutput
    {
        void WriteOutput(IDictionary<string, int> wordFrequency);
    }

    public class CsvOutput : IReceiverOutput
    {
        public bool OutputStatus;
        readonly string _filepath;
        public readonly List<string> FileOutput = new List<string>();

        public CsvOutput(string filepath)
        {
            this._filepath = filepath;
            OutputStatus = false;
        }

        public void WriteOutput(IDictionary<string, int> wordFrequency)
        {
            var csv = new StringBuilder();
            foreach (var line in wordFrequency)
            {
                var newLine = $"{line.Key},{line.Value}";
                csv.AppendLine(newLine);
                FileOutput.Add(newLine);
            }

            File.WriteAllText(_filepath, csv.ToString());
            OutputStatus = true;
        }
    }
}
