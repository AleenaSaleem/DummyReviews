using System;
using System.Collections.Generic;
using System.Linq;

namespace Sender
{
    public interface ISenderOutput
    {
        void WriteOutput(IEnumerable<IEnumerable<string>> data);
    }
    
    public class MockConsoleOutput : ISenderOutput
    {
        public List<List<string>> OutputOnConsole = new List<List<string>>();
        public int NRows, NColumns;
        public void WriteOutput(IEnumerable<IEnumerable<string>> data)
        {
            var dataList = data.ToList();
            NRows = ConsoleOutput.GetNumberOfRows(dataList);
            NColumns = ConsoleOutput.GetNumberOfColumns(dataList);
            foreach (var newRow in dataList.Select(row => row.ToList()))
            {
                OutputOnConsole.Add(newRow);
            }
        }
    }

    public class ConsoleOutput : ISenderOutput
    {
        public void WriteOutput(IEnumerable<IEnumerable<string>> data)
        {
            var dataList = data.ToList();
            var nRows = GetNumberOfRows(dataList);
            var nColumns = GetNumberOfColumns(dataList);
            Console.WriteLine(nRows);
            Console.WriteLine(nColumns);
            foreach (var value in dataList.SelectMany(row => row))
            {
                Console.WriteLine(value);
            }
        }

        public static int GetNumberOfColumns(IEnumerable<IEnumerable<string>> data)
        {
            var colCount = 0;
            foreach (var row in data)
            {
                colCount += row.Count();
                break;
            }
            return colCount;
        }

        public static int GetNumberOfRows(IEnumerable<IEnumerable<string>> data)
        {
            return data.Count();
        }
    }
}
