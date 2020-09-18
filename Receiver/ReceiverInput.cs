using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Receiver
{
    public interface IReceiverInput
    {
        IEnumerable<IEnumerable<string>> ReadInput();
    }

    public class ConsoleInput : IReceiverInput
    {
        public IEnumerable<IEnumerable<string>> ReadInput()
        {
            var nRows = ReadNumberOfRowsFromConsole();
            var nCols = ReadNumberOfColumnsFromConsole();
            var inputFromSender = new List<List<string>>();
            for (var i = 0; i < nRows; i++)
            {
                var newRow = new List<string>();
                for (var j = 0; j < nCols; j++) newRow.Add(Console.ReadLine());
                inputFromSender.Add(newRow);
            }

            return inputFromSender;
        }
        public int ReadNumberOfRowsFromConsole()
        {
            var nRows=default(int);  
            nRows = int.Parse(Console.ReadLine());
            if(nRows!=null) return nRows;
            return 0;
        }
        public int ReadNumberOfColumnsFromConsole()
        {
            var nCols=default(int);
            nCols = int.Parse(Console.ReadLine());
            if(nCols!=null) return nCols;
            return 0;
        }

        public void InputExceptionHandler( IEnumerable<IEnumerable<string>> input)
        {
            if (!input.Any()) throw new InvalidDataException();
        }
    }
}
