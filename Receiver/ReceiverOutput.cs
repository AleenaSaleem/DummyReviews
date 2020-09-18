using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Receiver
{
    public interface IReceiverOutput
    {
        void WriteOutput(IDictionary<string, int> wordFrequency);
    }

    public class CSVOutput : IReceiverOutput
    {
        private readonly string filepath;

        public CSVOutput(string filepath)
        {
            this.filepath = filepath;
        }

        public void WriteOutput(IDictionary<string, int> wordFrequency)
        {
            var csv = new StringBuilder();
            foreach (var line in wordFrequency)
            {
                var newLine = string.Format("{0},{1}", line.Key, line.Value);
                Console.WriteLine(newLine);
                csv.AppendLine(newLine);
            }

            File.WriteAllText(filepath, csv.ToString());
        }
    }
}