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

    public class CsvInput : ISenderInput
    {
        public string Filepath;
        public CsvInput(string filepath)
        {
            this.Filepath = filepath;
        }

        public void CheckIfFileExists()
        {
            if (!File.Exists(Filepath))
            {
                throw new FileNotFoundException();
            }
        }

        public bool InputExceptionHandler()
        {
            CheckIfFileExists();
            return true;
        }

        public List<List<string>> CsvData = new List<List<string>>();
        public IEnumerable<IEnumerable<string>> ReadInput()
        {
            using (var reader = new StreamReader(Filepath))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    //Note: The first row in this list contains headers from CSV file
                    CsvData.Add(values.ToList());
                }

            }
            return CsvData;
        }

    }
}
