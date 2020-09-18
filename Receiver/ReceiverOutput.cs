using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Receiver
{
    public interface IReceiverOutput
    {
        void WriteOutput(IDictionary<string, int> WordFrequency);
    }
    public class CsvOutput:IReceiverOutput
    {
        public bool outputStatus;
        readonly string filepath;
        public List<string> fileOutput = new List<string>();
        public CsvOutput(string filepath)
        {
            this.filepath = filepath;
            outputStatus = false;
        }
        public void WriteOutput(IDictionary<string, int> WordFrequency)
        {
            var csv = new StringBuilder();
            foreach(var line in WordFrequency)
            {
                var newLine = string.Format("{0},{1}", line.Key, line.Value);
                csv.AppendLine(newLine);
                fileOutput.Add(newLine);
            }
           
            File.WriteAllText(filepath, csv.ToString());
            outputStatus = true;
        }
    }
}
