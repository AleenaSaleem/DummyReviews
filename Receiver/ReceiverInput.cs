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
            int nRows=0;  
            nRows = int.Parse(Console.ReadLine());
            return nRows;
        }
        public int ReadNumberOfColumnsFromConsole()
        {
            int nCols=0;
            nCols = int.Parse(Console.ReadLine());
            return nCols;
        }

        public void InputExceptionHandler( IEnumerable<IEnumerable<string>> input)
        {
            if (!input.Any()) throw new InvalidDataException();
        }
    }
}
