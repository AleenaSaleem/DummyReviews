using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Sender
{

    public interface ISenderInput
    {
        IEnumerable<IEnumerable<string>> ReadInput();
        bool InputExceptionHandler();
    }

    public class CSVInput : ISenderInput
    {
        public string filepath;
        public CSVInput(string filepath)
        {
            this.filepath = filepath;
        }
        public bool InputExceptionHandler()
        {
            bool status;
            if (!File.Exists(filepath))
            {
                status = true;
                throw new FileNotFoundException();
            }
            status = false;
            return status;

        }
        public List<List<string>> csvData = new List<List<string>>();
        public IEnumerable<IEnumerable<string>> ReadInput()
        {
            using (var reader = new StreamReader(filepath))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    //Note: The first row in this list contains headers from CSV file
                    csvData.Add(values.ToList<string>());
                }


            }
            return csvData;
        }

    }
}

