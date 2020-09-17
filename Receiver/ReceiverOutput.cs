using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receiver
{
    public interface IReceiverOutput
    {
        void WriteOutput(IDictionary<string, int> WordFrequency);
    }
    public class CSVOutput:IReceiverOutput
    {
        string filepath;
        public CSVOutput(string filepath)
        {
            this.filepath = filepath;
        }
        public void WriteOutput(IDictionary<string, int> WordFrequency)
        {
            var csv = new StringBuilder();
            foreach(var line in WordFrequency)
            {
                var newLine = string.Format("{0},{1}", line.Key, line.Value);
                csv.AppendLine(newLine);
            }
           
            File.WriteAllText(filepath, csv.ToString());
        }
    }
}

